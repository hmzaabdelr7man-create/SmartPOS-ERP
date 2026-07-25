namespace SmartPOS.UI;

using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using SmartPOS.Application;
using SmartPOS.Contracts.Errors;
using SmartPOS.Contracts.Services;
using SmartPOS.Backup;
using SmartPOS.Barcode;
using SmartPOS.Database;
using SmartPOS.Infrastructure;
using SmartPOS.Infrastructure.Logging;
using SmartPOS.Printing;
using SmartPOS.Reporting;
using SmartPOS.Core.Configuration;
using SmartPOS.Core.Constants;
using SmartPOS.Core.Enums;
using SmartPOS.UI.Navigation;
using SmartPOS.UI.Services;
using SmartPOS.UI.ViewModels;
using SmartPOS.UI.Views;
using SmartPOS.UI.Views.Pages;
using Application = System.Windows.Application;
using ErrorSeverity = SmartPOS.Contracts.Errors.ErrorSeverity;
using UnhandledExceptionEventArgs = System.UnhandledExceptionEventArgs;

/// <summary>
/// The entry point and startup orchestrator for the Smart POS ERP WPF application.
/// </summary>
public partial class App : Application
{
    private IHost? _host;
    private ILogger? _logger;

    /// <summary>Initializes a new instance of the <see cref="App" /> class.</summary>
    public App()
    {
        DispatcherUnhandledException += OnDispatcherUnhandledException;
        AppDomain.CurrentDomain.UnhandledException += OnDomainUnhandledException;
        TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
    }

    /// <inheritdoc />
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(ApplicationConstants.ConfigFileName, optional: false, reloadOnChange: true)
            .AddJsonFile(ApplicationConstants.UserConfigFileName, optional: true, reloadOnChange: true)
            .Build();

        _logger = SerilogConfigurator.CreateLogger(configuration);
        Log.Logger = _logger;
        _logger.Information("Starting {ProductName}", ApplicationConstants.ProductName);

        var userSettingsPath = Path.Combine(AppContext.BaseDirectory, ApplicationConstants.UserConfigFileName);
        var featureAssemblies = new[]
        {
            typeof(ReportingFeatureModule).Assembly,
            typeof(PrintingFeatureModule).Assembly,
            typeof(BarcodeFeatureModule).Assembly,
            typeof(BackupFeatureModule).Assembly,
        };

        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                var databaseOptions = new DatabaseOptions();
                context.Configuration.GetSection(DatabaseOptions.SectionName).Bind(databaseOptions);
                services.AddDatabase(databaseOptions);

                services.AddInfrastructure(context.Configuration, userSettingsPath, featureAssemblies);
                services.AddApplication(typeof(SmartPOS.Application.DependencyInjection).Assembly);

                services.AddSingleton<IThemeService, WpfThemeService>();
                services.AddSingleton<ILanguageService, WpfLanguageService>();

                services.AddSingleton<INavigationService, NavigationService>();
                services.AddTransient<LoginViewModel>();
                services.AddTransient<LoginWindow>();
                services.AddTransient<ShellViewModel>();
                services.AddTransient<ShellWindow>();
                services.AddTransient<HomePage>();
                services.AddTransient<HomeViewModel>();
            })
            .Build();

        await _host.StartAsync();

        ApplyPersistedPreferences();
        RegisterNavigationPages();
        ShowSplashScreenThenLogin();
    }

    private void ApplyPersistedPreferences()
    {
        var settings = _host!.Services.GetRequiredService<ISettingsService>();
        var themeService = _host.Services.GetRequiredService<IThemeService>();
        var languageService = _host.Services.GetRequiredService<ILanguageService>();

        var themeOptions = settings.GetAsync<SmartPOS.Core.Configuration.ThemeOptions>().GetAwaiter().GetResult();
        themeService.ApplyTheme(themeOptions.Current);

        var languageOptions = settings.GetAsync<SmartPOS.Core.Configuration.LanguageOptions>().GetAwaiter().GetResult();
        languageService.ApplyLanguage(languageOptions.Current);
    }

    private void RegisterNavigationPages()
    {
        var navigation = _host!.Services.GetRequiredService<INavigationService>();
        navigation.RegisterPage(new PageDescriptor
        {
            Key = "home",
            ViewType = typeof(HomePage),
            ViewModelType = typeof(HomeViewModel),
            IconGlyph = "\uE80F",
        });
    }

    private void ShowSplashScreenThenLogin()
    {
        var splash = new Views.SplashScreen();
        splash.Closed += (_, _) => ShowLoginWindow();
        splash.Show();
    }

    private void ShowLoginWindow()
    {
        var loginViewModel = _host!.Services.GetRequiredService<LoginViewModel>();
        var loginWindow = new LoginWindow(loginViewModel);
        loginViewModel.LoginSucceeded += (_, _) =>
        {
            loginWindow.Close();
            ShowShellWindow();
        };
        loginWindow.Show();
    }

    private void ShowShellWindow()
    {
        var shellViewModel = _host!.Services.GetRequiredService<ShellViewModel>();
        var shellWindow = new ShellWindow(shellViewModel);
        shellViewModel.LogoutRequested += (_, _) =>
        {
            shellWindow.Close();
            ShowLoginWindow();
        };
        shellWindow.Show();
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        var handler = _host?.Services.GetService<IExceptionHandler>();
        var info = handler?.Handle(e.Exception) ?? new ErrorInfo { Title = "Error", Message = e.Exception.Message, Severity = ErrorSeverity.Critical };
        _logger?.Error(e.Exception, "Unhandled dispatcher exception: {Title}", info.Title);
        MessageBox.Show(info.Message, info.Title, MessageBoxButton.OK, info.Severity == ErrorSeverity.Warning ? MessageBoxImage.Warning : MessageBoxImage.Error);
        e.Handled = true;
    }

    private void OnDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception exception)
        {
            _logger?.Fatal(exception, "AppDomain unhandled exception. IsTerminating={IsTerminating}", e.IsTerminating);
        }
    }

    private void OnUnobservedTaskException(object? sender, System.Threading.Tasks.UnobservedTaskExceptionEventArgs e)
    {
        _logger?.Error(e.Exception, "Unobserved task exception.");
        e.SetObserved();
    }

    /// <inheritdoc />
    protected override async void OnExit(ExitEventArgs e)
    {
        if (_host is not null)
        {
            await _host.StopAsync().ConfigureAwait(true);
            _host.Dispose();
        }

        Log.CloseAndFlush();
        base.OnExit(e);
    }
}
