namespace SmartPOS.Shared.Configuration;

using SmartPOS.Shared.Enums;

/// <summary>
/// Contains the configuration options for the visual theme of the user interface.
/// </summary>
public sealed class ThemeOptions
{
    /// <summary>Gets the configuration section name used to bind these options.</summary>
    public const string SectionName = "Theme";

    /// <summary>Gets or sets the theme applied to the user interface.</summary>
    public AppTheme Current { get; set; } = AppTheme.Light;

    /// <summary>Gets or sets a value indicating whether the theme should follow the host operating system preference.</summary>
    public bool FollowSystem { get; set; } = false;
}
