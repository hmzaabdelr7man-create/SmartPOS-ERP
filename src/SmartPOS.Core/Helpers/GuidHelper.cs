namespace SmartPOS.Core.Helpers;

/// <summary>
/// Provides helper utilities for working with <see cref="Guid" /> values.
/// </summary>
public static class GuidHelper
{
    /// <summary>Gets a value indicating whether the supplied identifier is empty.</summary>
    /// <param name="value">The identifier to check.</param>
    /// <returns><see langword="true" /> when the identifier equals <see cref="Guid.Empty" />; otherwise <see langword="false" />.</returns>
    public static bool IsEmpty(Guid value) => value == Guid.Empty;

    /// <summary>Gets a value indicating whether the supplied identifier is a non-empty value.</summary>
    /// <param name="value">The identifier to check.</param>
    /// <returns><see langword="true" /> when the identifier is not <see cref="Guid.Empty" />; otherwise <see langword="false" />.</returns>
    public static bool IsNotEmpty(Guid value) => value != Guid.Empty;
}
