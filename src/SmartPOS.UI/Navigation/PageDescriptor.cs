namespace SmartPOS.UI.Navigation;

using System.Windows.Controls;

/// <summary>
/// Describes a navigable page registered with the <see cref="INavigationService" />.
/// </summary>
public sealed class PageDescriptor
{
    /// <summary>Gets or sets the unique key used to navigate to the page.</summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>Gets or sets the type of the view that should be displayed.</summary>
    public Type ViewType { get; set; } = typeof(UserControl);

    /// <summary>Gets or sets the type of the view model that should be bound to the view.</summary>
    public Type ViewModelType { get; set; } = typeof(object);

    /// <summary>Gets or sets the glyph used to represent the page in the navigation bar.</summary>
    public string IconGlyph { get; set; } = string.Empty;
}
