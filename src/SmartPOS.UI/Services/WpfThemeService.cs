namespace SmartPOS.UI.Services;

using System.Windows;
using SmartPOS.Contracts.Services;
using SmartPOS.Core.Enums;

/// <summary>
/// A WPF implementation of <see cref="IThemeService" /> that swaps merged resource dictionaries to change the active theme.
/// </summary>
public sealed class WpfThemeService : IThemeService
{
    private const string LightThemeSource = "Themes/LightTheme.xaml";
    private const string DarkThemeSource = "Themes/DarkTheme.xaml";

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

        var source = theme == AppTheme.Dark ? DarkThemeSource : LightThemeSource;
        var dictionaries = System.Windows.Application.Current.Resources.MergedDictionaries;
        ResourceDictionary? existing = null;
        foreach (var dict in dictionaries)
        {
            if (dict.Source is not null && (dict.Source.OriginalString.Contains("LightTheme", StringComparison.OrdinalIgnoreCase) || dict.Source.OriginalString.Contains("DarkTheme", StringComparison.OrdinalIgnoreCase)))
            {
                existing = dict;
                break;
            }
        }

        var newDictionary = new ResourceDictionary { Source = new Uri(source, UriKind.Relative) };
        if (existing is not null)
        {
            var index = dictionaries.IndexOf(existing);
            dictionaries[index] = newDictionary;
        }
        else
        {
            dictionaries.Add(newDictionary);
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
