namespace SmartPOS.Contracts.Services;

using SmartPOS.Core.Enums;

/// <summary>
/// Provides control over the visual theme applied to the user interface.
/// </summary>
public interface IThemeService
{
    /// <summary>Gets the currently applied theme.</summary>
    AppTheme CurrentTheme { get; }

    /// <summary>Applies the supplied theme to the user interface.</summary>
    /// <param name="theme">The theme to apply.</param>
    void ApplyTheme(AppTheme theme);

    /// <summary>Toggles between the light and dark themes.</summary>
    /// <returns>The theme that is now active.</returns>
    AppTheme Toggle();

    /// <summary>Occurs when the active theme has changed.</summary>
    event EventHandler<AppTheme>? ThemeChanged;
}
