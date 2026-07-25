namespace SmartPOS.UI.Views;

using System.Windows;
using System.Windows.Controls;
using SmartPOS.UI.Navigation;
using SmartPOS.UI.ViewModels;

/// <summary>
/// The main application shell window that hosts navigation and content pages.
/// </summary>
public partial class ShellWindow : Window
{
    /// <summary>Initializes a new instance of the <see cref="ShellWindow" /> class.</summary>
    public ShellWindow()
    {
        InitializeComponent();
    }

    /// <summary>Initializes a new instance of the <see cref="ShellWindow" /> class with the supplied view model.</summary>
    /// <param name="viewModel">The view model that drives the shell window.</param>
    public ShellWindow(ShellViewModel viewModel)
        : this()
    {
        DataContext = viewModel;
        viewModel.LogoutRequested += OnLogoutRequested;
    }

    private void OnNavigationSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (DataContext is ShellViewModel viewModel && NavigationList.SelectedItem is PageDescriptor descriptor)
        {
            viewModel.NavigateCommand.Execute(descriptor.Key);
        }
    }

    private void OnToggleTheme(object sender, RoutedEventArgs e)
    {
        if (DataContext is ShellViewModel viewModel)
        {
            viewModel.ToggleThemeCommand.Execute(null);
        }
    }

    private void OnToggleLanguage(object sender, RoutedEventArgs e)
    {
        if (DataContext is ShellViewModel viewModel)
        {
            viewModel.ToggleLanguageCommand.Execute(null);
        }
    }

    private void OnLogout(object sender, RoutedEventArgs e)
    {
        if (DataContext is ShellViewModel viewModel)
        {
            viewModel.LogoutCommand.Execute(null);
        }
    }

    private void OnLogoutRequested(object? sender, EventArgs e)
    {
        Close();
    }
}
