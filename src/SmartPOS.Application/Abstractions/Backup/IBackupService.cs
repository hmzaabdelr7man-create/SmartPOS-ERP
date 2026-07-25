namespace SmartPOS.Application.Abstractions.Backup;

/// <summary>
/// Creates and manages application backup archives.
/// </summary>
public interface IBackupService
{
    /// <summary>Creates a backup archive of the application data.</summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A descriptor of the created backup archive.</returns>
    Task<BackupDescriptor> CreateBackupAsync(CancellationToken cancellationToken = default);

    /// <summary>Gets the list of backup archives currently retained.</summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A read-only list of backup descriptors.</returns>
    Task<IReadOnlyList<BackupDescriptor>> ListBackupsAsync(CancellationToken cancellationToken = default);
}
