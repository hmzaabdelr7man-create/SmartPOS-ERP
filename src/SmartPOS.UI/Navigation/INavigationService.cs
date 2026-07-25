namespace SmartPOS.UI.Navigation;

using System.Collections.ObjectModel;
using System.Windows.Controls;

/// <summary>
/// Provides navigation between registered pages within the shell window.
/// </summary>
public interface INavigationService
{
    /// <summary>Gets the descriptor of the page currently displayed.</summary>
    PageDescriptor? CurrentPage { get; }

    /// <summary>Gets the view currently displayed in the content host.</summary>
    UserControl? CurrentView { get; }

    /// <summary>Gets the read-only collection of registered pages.</summary>
    ReadOnlyObservableCollection<PageDescriptor> Pages { get; }

    /// <summary>Registers a page with the navigation service.</summary>
    /// <param name="descriptor">The descriptor describing the page to register.</param>
    void RegisterPage(PageDescriptor descriptor);

    /// <summary>Navigates to the page with the specified key.</summary>
    /// <param name="key">The key of the page to navigate to.</param>
    void NavigateTo(string key);

    /// <summary>Occurs when the current page has changed.</summary>
    event EventHandler<PageDescriptor?>? CurrentPageChanged;
}
