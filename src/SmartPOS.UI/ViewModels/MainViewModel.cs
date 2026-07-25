using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartPOS.Application.Abstractions;
using SmartPOS.Shared.Enums;

namespace SmartPOS.UI.ViewModels;

/// <summary>
/// View model for the main shell. Hosts the commands that switch theme and
/// language at runtime, demonstrating that the foundation wiring works.
/// No business logic lives here; everything delegates to application services.
/// </summary>
public partial class MainViewModel : ObservableObject
{
    private readonly IThemeService _themeService;
    private readonly ILanguageService _languageService;
    private readonly ISettingsService _settingsService;

    /// <summary>Initializes a new instance with the runtime services.</summary>
    public MainViewModel(IThemeService themeService, ILanguageService languageService, ISettingsService settingsService)
    {
        _themeService = themeService;
        _languageService = languageService;
        _settingsService = settingsService;
        _themeService.ThemeChanged += (_, theme) => CurrentTheme = theme;
        _languageService.LanguageChanged += (_, language) => CurrentLanguage = language;
        CurrentTheme = _themeService.CurrentTheme;
        CurrentLanguage = _languageService.CurrentLanguage;
    }

    /// <summary>The theme currently applied to the shell.</summary>
    [ObservableProperty]
    private AppTheme _currentTheme;

    /// <summary>The UI language currently applied to the shell.</summary>
    [ObservableProperty]
    private AppLanguage _currentLanguage;

    /// <summary>Toggles the theme and persists the choice.</summary>
    [RelayCommand]
    private async Task ToggleThemeAsync()
    {
        _themeService.Toggle();
        await _settingsService.SetAsync(new Shared.Configuration.ThemeOptions { Current = _themeService.CurrentTheme });
    }

    /// <summary>Toggles the UI language and persists the choice.</summary>
    [RelayCommand]
    private async Task ToggleLanguageAsync()
    {
        _languageService.Toggle();
        await _settingsService.SetAsync(new Shared.Configuration.LanguageOptions { Current = _languageService.CurrentLanguage });
    }
}
