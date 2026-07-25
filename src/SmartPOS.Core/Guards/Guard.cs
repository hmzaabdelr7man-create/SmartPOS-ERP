namespace SmartPOS.Core.Guards;

/// <summary>
/// Provides guard-clause validation that throws <see cref="ArgumentException" /> or <see cref="ArgumentNullException" /> when a precondition is violated.
/// </summary>
public static class Guard
{
    /// <summary>Throws <see cref="ArgumentNullException" /> when the supplied value is <see langword="null" />.</summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The non-null value.</returns>
    public static T AgainstNull<T>(T? value, string paramName)
        where T : class
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName);
        }

        return value;
    }

    /// <summary>Throws <see cref="ArgumentException" /> when the supplied string is null, empty, or whitespace.</summary>
    /// <param name="value">The string to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The non-empty string.</returns>
    public static string AgainstNullOrWhiteSpace(string? value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("The value cannot be null, empty, or whitespace.", paramName);
        }

        return value;
    }

    /// <summary>Throws <see cref="ArgumentOutOfRangeException" /> when the supplied value is less than the specified minimum.</summary>
    /// <param name="value">The value to check.</param>
    /// <param name="min">The inclusive minimum allowed value.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The value, guaranteed to be at least <paramref name="min" />.</returns>
    public static int AgainstNegative(int value, int min, string paramName)
    {
        if (value < min)
        {
            throw new ArgumentOutOfRangeException(paramName, value, $"The value must be greater than or equal to {min}.");
        }

        return value;
    }

    /// <summary>Throws <see cref="ArgumentException" /> when the supplied enumerable is null or empty.</summary>
    /// <typeparam name="T">The element type of the enumerable.</typeparam>
    /// <param name="value">The enumerable to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The non-empty enumerable.</returns>
    public static IEnumerable<T> AgainstEmpty<T>(IEnumerable<T>? value, string paramName)
    {
        if (value is null || !value.Any())
        {
            throw new ArgumentException("The collection cannot be null or empty.", paramName);
        }

        return value;
    }
}
