namespace SmartPOS.UI.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;

/// <summary>
/// The view model that drives the home page.
/// </summary>
public partial class HomeViewModel : ObservableObject
{
    /// <summary>Gets or sets the greeting message displayed on the home page.</summary>
    [ObservableProperty]
    private string _greeting = "Welcome to Smart POS ERP";
}
