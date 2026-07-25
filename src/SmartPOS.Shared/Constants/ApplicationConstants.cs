namespace SmartPOS.Shared.Constants;

/// <summary>
/// Contains application-wide constant values that are shared across all layers.
/// </summary>
public static class ApplicationConstants
{
    /// <summary>Gets the product name displayed throughout the application.</summary>
    public const string ProductName = "Smart POS ERP";

    /// <summary>Gets the invariant culture used for storage and formatting of culture-neutral data.</summary>
    public const string InvariantCulture = "en-US";

    /// <summary>Gets the default UI culture used when no user preference has been persisted.</summary>
    public const string DefaultUICulture = "ar";

    /// <summary>Gets the file name of the primary application configuration file.</summary>
    public const string ConfigFileName = "appsettings.json";

    /// <summary>Gets the file name of the user-scoped configuration file that overrides the primary settings.</summary>
    public const string UserConfigFileName = "appsettings.user.json";
}
