namespace SmartPOS.Application.Abstractions.Backup;

/// <summary>
/// Describes a backup archive produced by an <see cref="IBackupService" />.
/// </summary>
public sealed class BackupDescriptor
{
    /// <summary>Gets or sets the full path of the backup archive.</summary>
    public string FilePath { get; set; } = string.Empty;

    /// <summary>Gets or sets the size, in bytes, of the backup archive.</summary>
    public long SizeBytes { get; set; }

    /// <summary>Gets or sets the UTC date and time the backup was created.</summary>
    public DateTime CreatedAtUtc { get; set; }
}
