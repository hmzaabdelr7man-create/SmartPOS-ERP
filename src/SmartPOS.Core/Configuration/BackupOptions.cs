namespace SmartPOS.Core.Configuration;

/// <summary>
/// Contains the configuration options for the application backup feature.
/// </summary>
public sealed class BackupOptions
{
    /// <summary>Gets the configuration section name used to bind these options.</summary>
    public const string SectionName = "Backup";

    /// <summary>Gets or sets the folder where backup archives are stored.</summary>
    public string DestinationFolder { get; set; } = "Backups";

    /// <summary>Gets or sets a value indicating whether a backup should be created when the application exits.</summary>
    public bool BackupOnExit { get; set; } = false;

    /// <summary>Gets or sets the maximum number of backup files retained before older files are pruned.</summary>
    public int MaxRetainedFiles { get; set; } = 10;
}
