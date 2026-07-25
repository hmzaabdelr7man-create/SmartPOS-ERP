namespace SmartPOS.Core.Helpers;

/// <summary>
/// Provides helper utilities for working with date and time values.
/// </summary>
public static class DateTimeHelper
{
    /// <summary>Gets the current UTC date and time.</summary>
    public static DateTime UtcNow => DateTime.UtcNow;

    /// <summary>Gets the current UTC date with the time component set to midnight.</summary>
    public static DateTime UtcToday => DateTime.UtcNow.Date;

    /// <summary>Converts the supplied date to a Unix epoch timestamp expressed in seconds.</summary>
    /// <param name="value">The date to convert.</param>
    /// <returns>The number of seconds elapsed since 1970-01-01T00:00:00Z.</returns>
    public static long ToUnixEpochSeconds(DateTime value)
    {
        return new DateTimeOffset(value, TimeSpan.Zero).ToUnixTimeSeconds();
    }
}
