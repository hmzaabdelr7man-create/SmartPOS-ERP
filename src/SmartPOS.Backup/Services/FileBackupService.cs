namespace SmartPOS.Backup.Services;

using System.IO;
using System.IO.Compression;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SmartPOS.Application.Abstractions.Backup;
using SmartPOS.Core.Configuration;
using SmartPOS.Core.Enums;

/// <summary>
/// A file-based implementation of <see cref="IBackupService" /> that creates ZIP archives and prunes old backups.
/// </summary>
public class FileBackupService : IBackupService
{
    private readonly BackupOptions _options;
    private readonly DatabaseOptions _databaseOptions;
    private readonly ILogger<FileBackupService> _logger;
    private readonly string _dataSource;

    /// <summary>Initializes a new instance of the <see cref="FileBackupService" /> class.</summary>
    /// <param name="options">The backup options describing the destination folder and retention policy.</param>
    /// <param name="databaseOptions">The database options used to resolve the SQLite data-source file path.</param>
    /// <param name="logger">The logger used to record backup operations.</param>
    public FileBackupService(IOptions<BackupOptions> options, IOptions<DatabaseOptions> databaseOptions, ILogger<FileBackupService> logger)
    {
        _options = options.Value;
        _databaseOptions = databaseOptions.Value;
        _logger = logger;
        _dataSource = ResolveDataSource(_databaseOptions);
    }

    /// <summary>
    /// Resolves the SQLite data-source file path from the configured connection string.
    /// For non-file providers such as PostgreSQL there is no local file to archive and an empty path is returned.
    /// </summary>
    private static string ResolveDataSource(DatabaseOptions databaseOptions)
    {
        if (databaseOptions.Provider != DatabaseProvider.Sqlite)
        {
            return string.Empty;
        }

        var dataSource = ExtractValue(databaseOptions.SqliteConnectionString, "Data Source")
            ?? ExtractValue(databaseOptions.SqliteConnectionString, "DataSource")
            ?? string.Empty;

        if (string.IsNullOrWhiteSpace(dataSource))
        {
            return string.Empty;
        }

        return Path.IsPathRooted(dataSource)
            ? dataSource
            : Path.Combine(AppContext.BaseDirectory, dataSource);
    }

    /// <summary>Extracts the value of a key from a key=value connection string.</summary>
    private static string? ExtractValue(string connectionString, string key)
    {
        var segments = connectionString.Split(';', StringSplitOptions.RemoveEmptyEntries);
        foreach (var segment in segments)
        {
            var parts = segment.Split('=', 2, StringSplitOptions.TrimEntries);
            if (parts.Length == 2 && string.Equals(parts[0], key, StringComparison.OrdinalIgnoreCase))
            {
                return parts[1].Trim();
            }
        }

        return null;
    }

    /// <inheritdoc />
    public async Task<BackupDescriptor> CreateBackupAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        Directory.CreateDirectory(_options.DestinationFolder);

        var timestamp = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss", System.Globalization.CultureInfo.InvariantCulture);
        var fileName = $"backup-{timestamp}.zip";
        var filePath = Path.Combine(_options.DestinationFolder, fileName);

        await using (var archiveStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
        using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create))
        {
            if (string.IsNullOrEmpty(_dataSource))
            {
                _logger.LogWarning("Skipping database file backup: provider {Provider} has no local data file.", _databaseOptions.Provider);
            }
            else if (File.Exists(_dataSource))
            {
                var entry = archive.CreateEntry(Path.GetFileName(_dataSource));
                await using var entryStream = entry.Open();
                await using var sourceStream = new FileStream(_dataSource, FileMode.Open, FileAccess.Read, FileShare.Read);
                await sourceStream.CopyToAsync(entryStream, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _logger.LogWarning("Database file {DataSource} was not found; an empty archive was created.", _dataSource);
            }
        }

        var info = new FileInfo(filePath);
        var descriptor = new BackupDescriptor
        {
            FilePath = filePath,
            SizeBytes = info.Length,
            CreatedAtUtc = DateTime.UtcNow,
        };

        _logger.LogInformation("Created backup archive {FilePath} ({SizeBytes} bytes).", descriptor.FilePath, descriptor.SizeBytes);
        PruneOldBackups();
        return descriptor;
    }

    /// <inheritdoc />
    public Task<IReadOnlyList<BackupDescriptor>> ListBackupsAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (!Directory.Exists(_options.DestinationFolder))
        {
            return Task.FromResult<IReadOnlyList<BackupDescriptor>>(Array.Empty<BackupDescriptor>());
        }

        var descriptors = new List<BackupDescriptor>();
        foreach (var file in Directory.EnumerateFiles(_options.DestinationFolder, "backup-*.zip"))
        {
            var info = new FileInfo(file);
            descriptors.Add(new BackupDescriptor
            {
                FilePath = file,
                SizeBytes = info.Length,
                CreatedAtUtc = info.CreationTimeUtc,
            });
        }

        return Task.FromResult<IReadOnlyList<BackupDescriptor>>(descriptors);
    }

    private void PruneOldBackups()
    {
        if (_options.MaxRetainedFiles <= 0 || !Directory.Exists(_options.DestinationFolder))
        {
            return;
        }

        var files = Directory.EnumerateFiles(_options.DestinationFolder, "backup-*.zip")
            .Select(f => new FileInfo(f))
            .OrderByDescending(f => f.CreationTimeUtc)
            .Skip(_options.MaxRetainedFiles)
            .ToList();

        foreach (var file in files)
        {
            try
            {
                file.Delete();
                _logger.LogInformation("Pruned old backup {FilePath}.", file.FullName);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to prune old backup {FilePath}.", file.FullName);
            }
        }
    }
}
