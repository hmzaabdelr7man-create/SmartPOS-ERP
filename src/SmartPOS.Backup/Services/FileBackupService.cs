namespace SmartPOS.Backup.Services;

using System.IO;
using System.IO.Compression;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SmartPOS.Application.Abstractions.Backup;
using SmartPOS.Shared.Configuration;

/// <summary>
/// A file-based implementation of <see cref="IBackupService" /> that creates ZIP archives and prunes old backups.
/// </summary>
public class FileBackupService : IBackupService
{
    private readonly BackupOptions _options;
    private readonly ILogger<FileBackupService> _logger;
    private readonly string _dataSource;

    /// <summary>Initializes a new instance of the <see cref="FileBackupService" /> class.</summary>
    /// <param name="options">The backup options describing the destination folder and retention policy.</param>
    /// <param name="logger">The logger used to record backup operations.</param>
    public FileBackupService(IOptions<BackupOptions> options, ILogger<FileBackupService> logger)
    {
        _options = options.Value;
        _logger = logger;
        _dataSource = "smartpos.db";
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
            if (File.Exists(_dataSource))
            {
                var entry = archive.CreateEntry(Path.GetFileName(_dataSource));
                await using var entryStream = entry.Open();
                await using var sourceStream = new FileStream(_dataSource, FileMode.Open, FileAccess.Read, FileShare.Read);
                await sourceStream.CopyToAsync(entryStream, cancellationToken).ConfigureAwait(false);
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
