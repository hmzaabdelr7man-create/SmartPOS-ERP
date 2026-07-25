namespace SmartPOS.UI.Navigation;

using System.Collections.ObjectModel;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Default implementation of <see cref="INavigationService" /> that resolves views and view models from the dependency injection container.
/// </summary>
public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ObservableCollection<PageDescriptor> _pages = new();
    private readonly ReadOnlyObservableCollection<PageDescriptor> _readOnlyPages;
    private PageDescriptor? _currentPage;
    private UserControl? _currentView;

    /// <summary>Initializes a new instance of the <see cref="NavigationService" /> class.</summary>
    /// <param name="serviceProvider">The service provider used to resolve views and view models.</param>
    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _readOnlyPages = new ReadOnlyObservableCollection<PageDescriptor>(_pages);
    }

    /// <inheritdoc />
    public PageDescriptor? CurrentPage => _currentPage;

    /// <inheritdoc />
    public UserControl? CurrentView => _currentView;

    /// <inheritdoc />
    public ReadOnlyObservableCollection<PageDescriptor> Pages => _readOnlyPages;

    /// <inheritdoc />
    public void RegisterPage(PageDescriptor descriptor)
    {
        _pages.Add(descriptor);
    }

    /// <inheritdoc />
    public void NavigateTo(string key)
    {
        var descriptor = _pages.FirstOrDefault(p => p.Key == key);
        if (descriptor is null)
        {
            return;
        }

        var view = (UserControl)_serviceProvider.GetRequiredService(descriptor.ViewType);
        if (_serviceProvider.GetService(descriptor.ViewModelType) is { } viewModel)
        {
            view.DataContext = viewModel;
        }

        _currentView = view;
        _currentPage = descriptor;
        CurrentPageChanged?.Invoke(this, descriptor);
    }

    /// <inheritdoc />
    public event EventHandler<PageDescriptor?>? CurrentPageChanged;
}
