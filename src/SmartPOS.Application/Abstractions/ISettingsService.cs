namespace SmartPOS.Application.Abstractions;

/// <summary>
/// Provides read and write access to user-scoped application settings.
/// </summary>
public interface ISettingsService
{
    /// <summary>Gets the current value of a settings section.</summary>
    /// <typeparam name="T">The type of the settings section.</typeparam>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>The settings section value if present; otherwise a default instance.</returns>
    Task<T> GetAsync<T>(CancellationToken cancellationToken = default) where T : new();

    /// <summary>Persists a typed settings section to the user override file.</summary>
    /// <typeparam name="T">The type of the settings section.</typeparam>
    /// <param name="value">The settings section value to persist.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous set operation.</returns>
    Task SetAsync<T>(T value, CancellationToken cancellationToken = default) where T : class;
}
