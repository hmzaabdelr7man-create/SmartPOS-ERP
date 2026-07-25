namespace SmartPOS.UI.Views;

using System.Windows;
using System.Windows.Controls;
using SmartPOS.UI.ViewModels;

/// <summary>
/// The window that collects user credentials and initiates the login flow.
/// </summary>
public partial class LoginWindow : Window
{
    /// <summary>Initializes a new instance of the <see cref="LoginWindow" /> class.</summary>
    public LoginWindow()
    {
        InitializeComponent();
    }

    /// <summary>Initializes a new instance of the <see cref="LoginWindow" /> class with the supplied view model.</summary>
    /// <param name="viewModel">The view model that drives the login flow.</param>
    public LoginWindow(LoginViewModel viewModel)
        : this()
    {
        DataContext = viewModel;
        viewModel.LoginSucceeded += OnLoginSucceeded;
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is LoginViewModel viewModel)
        {
            viewModel.Password = PasswordBox.Password;
        }
    }

    private void OnLoginSucceeded(object? sender, EventArgs e)
    {
        Close();
    }
}
