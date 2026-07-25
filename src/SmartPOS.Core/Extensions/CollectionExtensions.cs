namespace SmartPOS.Core.Extensions;

/// <summary>
/// Provides extension methods for collection types.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>Returns an empty read-only list when the supplied enumerable is null; otherwise returns the enumerable as a read-only list.</summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="source">The enumerable to safeguard.</param>
    /// <returns>A read-only list that is never <see langword="null" />.</returns>
    public static IReadOnlyList<T> NullToEmpty<T>(this IEnumerable<T>? source)
    {
        return source is null ? Array.Empty<T>() : source.ToList();
    }

    /// <summary>Determines whether the supplied enumerable is null or contains no elements.</summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="source">The enumerable to check.</param>
    /// <returns><see langword="true" /> when the enumerable is null or empty; otherwise <see langword="false" />.</returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source)
    {
        return source is null || !source.Any();
    }
}
