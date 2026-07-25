namespace SmartPOS.Application.Common;

/// <summary>
/// Represents the outcome of an operation that returns a value.
/// </summary>
/// <typeparam name="T">The type of the value produced by a successful operation.</typeparam>
public sealed class Result<T>
{
    private Result(bool isSuccess, T? value, string? error)
    {
        IsSuccess = isSuccess;
        IsFailure = !isSuccess;
        Value = value;
        Error = error;
    }

    /// <summary>Gets a value indicating whether the operation succeeded.</summary>
    public bool IsSuccess { get; }

    /// <summary>Gets a value indicating whether the operation failed.</summary>
    public bool IsFailure { get; }

    /// <summary>Gets the value produced by a successful operation.</summary>
    public T? Value { get; }

    /// <summary>Gets the error message describing why a failed operation failed.</summary>
    public string? Error { get; }

    /// <summary>Creates a successful result containing the supplied value.</summary>
    /// <param name="value">The value produced by the operation.</param>
    /// <returns>A successful <see cref="Result{T}" />.</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1000:Do not declare static members on generic types", Justification = "Factory pattern is the established idiom for Result<T>.")]
    public static Result<T> Ok(T value) => new(true, value, null);

    /// <summary>Creates a failed result containing the supplied error message.</summary>
    /// <param name="error">A message describing the failure.</param>
    /// <returns>A failed <see cref="Result{T}" />.</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1000:Do not declare static members on generic types", Justification = "Factory pattern is the established idiom for Result<T>.")]
    public static Result<T> Fail(string error) => new(false, default, error);
}
