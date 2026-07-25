namespace SmartPOS.UI.Views;

using System.Windows;
using System.Windows.Threading;

/// <summary>
/// A splash screen displayed while the application is initializing.
/// </summary>
public partial class SplashScreen : Window
{
    private readonly DispatcherTimer _timer;

    /// <summary>Initializes a new instance of the <see cref="SplashScreen" /> class.</summary>
    public SplashScreen()
    {
        InitializeComponent();
        _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.8) };
        _timer.Tick += OnTimerElapsed;
        _timer.Start();
    }

    private void OnTimerElapsed(object? sender, EventArgs e)
    {
        _timer.Stop();
        Close();
    }
}
