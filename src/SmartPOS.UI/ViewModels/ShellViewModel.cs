namespace SmartPOS.UI.ViewModels;

using System.Collections.ObjectModel;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartPOS.Application.Abstractions;
using SmartPOS.Shared.Enums;
using SmartPOS.UI.Navigation;

/// <summary>
/// The view model that drives the main application shell window.
/// </summary>
public partial class ShellViewModel : ObservableObject
{
    private readonly IThemeService _themeService;
    private readonly ILanguageService _languageService;
    private readonly INavigationService _navigationService;
    private readonly ISettingsService _settingsService;

    /// <summary>Initializes a new instance of the <see cref="ShellViewModel" /> class.</summary>
    /// <param name="themeService">The service used to control the active theme.</param>
    /// <param name="languageService">The service used to control the active language.</param>
    /// <param name="navigationService">The service used to navigate between pages.</param>
    /// <param name="settingsService">The service used to persist user preferences.</param>
    public ShellViewModel(IThemeService themeService, ILanguageService languageService, INavigationService navigationService, ISettingsService settingsService)
    {
        _themeService = themeService;
        _languageService = languageService;
        _navigationService = navigationService;
        _settingsService = settingsService;

        _themeService.ThemeChanged += OnThemeChanged;
        _languageService.LanguageChanged += OnLanguageChanged;
        _navigationService.CurrentPageChanged += OnCurrentPageChanged;

        CurrentTheme = _themeService.CurrentTheme;
        CurrentLanguage = _languageService.CurrentLanguage;
        NavigationPages = _navigationService.Pages;
        _navigationService.NavigateTo("home");
    }

    /// <summary>Gets or sets the currently applied theme.</summary>
    [ObservableProperty]
    private AppTheme _currentTheme;

    /// <summary>Gets or sets the currently applied language.</summary>
    [ObservableProperty]
    private AppLanguage _currentLanguage;

    /// <summary>Gets or sets the view currently displayed in the shell content host.</summary>
    [ObservableProperty]
    private UserControl? _currentView;

    /// <summary>Gets the collection of pages available for navigation.</summary>
    public ReadOnlyObservableCollection<PageDescriptor> NavigationPages { get; }

    /// <summary>Gets the command used to toggle between the light and dark themes.</summary>
    [RelayCommand]
    private async Task ToggleThemeAsync()
    {
        _themeService.Toggle();
        await _settingsService.SetAsync(new SmartPOS.Shared.Configuration.ThemeOptions { Current = _themeService.CurrentTheme }).ConfigureAwait(true);
    }

    /// <summary>Gets the command used to toggle between the Arabic and English languages.</summary>
    [RelayCommand]
    private async Task ToggleLanguageAsync()
    {
        _languageService.Toggle();
        await _settingsService.SetAsync(new SmartPOS.Shared.Configuration.LanguageOptions { Current = _languageService.CurrentLanguage }).ConfigureAwait(true);
    }

    /// <summary>Gets the command used to navigate to a page with the specified key.</summary>
    [RelayCommand]
    private void Navigate(string key) => _navigationService.NavigateTo(key);

    /// <summary>Gets the command used to log out of the application.</summary>
    [RelayCommand]
    private void Logout() => LogoutRequested?.Invoke(this, EventArgs.Empty);

    /// <summary>Occurs when the user requests to log out of the application.</summary>
    public event EventHandler? LogoutRequested;

    private void OnThemeChanged(object? sender, AppTheme e) => CurrentTheme = e;

    private void OnLanguageChanged(object? sender, AppLanguage e) => CurrentLanguage = e;

    private void OnCurrentPageChanged(object? sender, PageDescriptor? e) => CurrentView = _navigationService.CurrentView;
}
