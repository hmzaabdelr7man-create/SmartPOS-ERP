namespace SmartPOS.Contracts.Services;

using SmartPOS.Core.Enums;

/// <summary>
/// Provides control over the display language applied to the user interface.
/// </summary>
public interface ILanguageService
{
    /// <summary>Gets the currently applied display language.</summary>
    AppLanguage CurrentLanguage { get; }

    /// <summary>Applies the supplied language to the user interface.</summary>
    /// <param name="language">The language to apply.</param>
    void ApplyLanguage(AppLanguage language);

    /// <summary>Toggles between the Arabic and English languages.</summary>
    /// <returns>The language that is now active.</returns>
    AppLanguage Toggle();

    /// <summary>Occurs when the active language has changed.</summary>
    event EventHandler<AppLanguage>? LanguageChanged;
}
