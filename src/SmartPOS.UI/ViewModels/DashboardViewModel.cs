using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartPOS.UI.ViewModels;

/// <summary>
/// View model for the placeholder dashboard page. Real content arrives in
/// later sprints.
/// </summary>
public partial class DashboardViewModel : ObservableObject
{
    /// <summary>Placeholder greeting shown on the dashboard.</summary>
    [ObservableProperty]
    private string _greeting = "Welcome to Smart POS ERP";
}
