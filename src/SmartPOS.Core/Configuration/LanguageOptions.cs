namespace SmartPOS.Core.Configuration;

using SmartPOS.Core.Enums;

/// <summary>
/// Contains the configuration options for the display language of the user interface.
/// </summary>
public sealed class LanguageOptions
{
    /// <summary>Gets the configuration section name used to bind these options.</summary>
    public const string SectionName = "Language";

    /// <summary>Gets or sets the language applied to the user interface.</summary>
    public AppLanguage Current { get; set; } = AppLanguage.Arabic;
}
