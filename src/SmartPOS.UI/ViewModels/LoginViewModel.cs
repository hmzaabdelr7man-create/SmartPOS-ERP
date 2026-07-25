namespace SmartPOS.UI.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

/// <summary>
/// The view model that drives the login window.
/// </summary>
public partial class LoginViewModel : ObservableObject
{
    /// <summary>Gets or sets the username entered by the user.</summary>
    [ObservableProperty]
    private string _username = string.Empty;

    /// <summary>Gets or sets the password entered by the user.</summary>
    [ObservableProperty]
    private string _password = string.Empty;

    /// <summary>Gets or sets a value indicating whether the error message should be visible.</summary>
    [ObservableProperty]
    private bool _errorVisibility;

    /// <summary>Gets the command used to attempt a login.</summary>
    [RelayCommand]
    private void Login()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorVisibility = true;
            return;
        }

        ErrorVisibility = false;
        LoginSucceeded?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>Occurs when the login attempt has succeeded.</summary>
    public event EventHandler? LoginSucceeded;
}
