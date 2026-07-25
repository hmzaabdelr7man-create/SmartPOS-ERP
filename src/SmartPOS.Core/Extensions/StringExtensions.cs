namespace SmartPOS.Core.Extensions;

/// <summary>
/// Provides extension methods for <see cref="string" /> values.
/// </summary>
public static class StringExtensions
{
    /// <summary>Returns <see cref="string.Empty" /> when the supplied value is null; otherwise returns the value unchanged.</summary>
    /// <param name="value">The string to safeguard.</param>
    /// <returns>A string that is never <see langword="null" />.</returns>
    public static string NullToEmpty(this string? value) => value ?? string.Empty;

    /// <summary>Trims the supplied string and returns <see langword="null" /> when the result is empty.</summary>
    /// <param name="value">The string to trim.</param>
    /// <returns>The trimmed string, or <see langword="null" /> when the trimmed result is empty.</returns>
    public static string? TrimToNull(this string? value)
    {
        var trimmed = value?.Trim();
        return string.IsNullOrEmpty(trimmed) ? null : trimmed;
    }
}
