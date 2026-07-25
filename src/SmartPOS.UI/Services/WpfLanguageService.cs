namespace SmartPOS.UI.Services;

using System.Globalization;
using System.Threading;
using System.Windows;
using SmartPOS.Application.Abstractions;
using SmartPOS.Shared.Enums;

/// <summary>
/// A WPF implementation of <see cref="ILanguageService" /> that switches culture, resource dictionary and flow direction.
/// </summary>
public sealed class WpfLanguageService : ILanguageService
{
    private const string ArabicResourceSource = "Resources/Localization/Strings.ar.xaml";
    private const string EnglishResourceSource = "Resources/Localization/Strings.en.xaml";
    private const string ArabicCulture = "ar";
    private const string EnglishCulture = "en";

    private AppLanguage _currentLanguage = AppLanguage.Arabic;

    /// <inheritdoc />
    public AppLanguage CurrentLanguage => _currentLanguage;

    /// <inheritdoc />
    public void ApplyLanguage(AppLanguage language)
    {
        if (_currentLanguage == language)
        {
            return;
        }

        var cultureName = language == AppLanguage.Arabic ? ArabicCulture : EnglishCulture;
        var source = language == AppLanguage.Arabic ? ArabicResourceSource : EnglishResourceSource;

        var culture = new CultureInfo(cultureName);
        Thread.CurrentThread.CurrentUICulture = culture;
        Thread.CurrentThread.CurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;

        var dictionaries = System.Windows.Application.Current.Resources.MergedDictionaries;
        ResourceDictionary? existing = null;
        foreach (var dict in dictionaries)
        {
            if (dict.Source is not null && dict.Source.OriginalString.Contains("Strings.", StringComparison.OrdinalIgnoreCase))
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

        System.Windows.Application.Current.MainWindow?.SetValue(FrameworkElement.FlowDirectionProperty, language == AppLanguage.Arabic ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);

        _currentLanguage = language;
        LanguageChanged?.Invoke(this, language);
    }

    /// <inheritdoc />
    public AppLanguage Toggle()
    {
        var next = _currentLanguage == AppLanguage.Arabic ? AppLanguage.English : AppLanguage.Arabic;
        ApplyLanguage(next);
        return next;
    }

    /// <inheritdoc />
    public event EventHandler<AppLanguage>? LanguageChanged;
}
