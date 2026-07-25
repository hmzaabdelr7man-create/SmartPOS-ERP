using System.Windows;
using SmartPOS.UI.ViewModels;

namespace SmartPOS.UI.Views;

/// <summary>
/// Code-behind for the main shell window. Resolves its view model from DI
/// and binds the data context. No business logic lives here.
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>Initializes a new instance and binds the view model.</summary>
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
