namespace SmartPOS.Infrastructure.Services;

using SmartPOS.Application.Abstractions;
using SmartPOS.Shared.Enums;

/// <summary>
/// A headless implementation of <see cref="IThemeService" /> that tracks the active theme without interacting with a user interface.
/// </summary>
public sealed class NullThemeService : IThemeService
{
    private AppTheme _currentTheme = AppTheme.Light;

    /// <inheritdoc />
    public AppTheme CurrentTheme => _currentTheme;

    /// <inheritdoc />
    public void ApplyTheme(AppTheme theme)
    {
        if (_currentTheme == theme)
        {
            return;
        }

        _currentTheme = theme;
        ThemeChanged?.Invoke(this, theme);
    }

    /// <inheritdoc />
    public AppTheme Toggle()
    {
        var next = _currentTheme == AppTheme.Light ? AppTheme.Dark : AppTheme.Light;
        ApplyTheme(next);
        return next;
    }

    /// <inheritdoc />
    public event EventHandler<AppTheme>? ThemeChanged;
}
