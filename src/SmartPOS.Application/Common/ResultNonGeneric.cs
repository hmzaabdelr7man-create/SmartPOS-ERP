namespace SmartPOS.Application.Common;

/// <summary>
/// Represents the outcome of an operation that does not return a value.
/// </summary>
public sealed class Result
{
    private Result(bool isSuccess, string? error)
    {
        IsSuccess = isSuccess;
        IsFailure = !isSuccess;
        Error = error;
    }

    /// <summary>Gets a value indicating whether the operation succeeded.</summary>
    public bool IsSuccess { get; }

    /// <summary>Gets a value indicating whether the operation failed.</summary>
    public bool IsFailure { get; }

    /// <summary>Gets the error message describing why a failed operation failed.</summary>
    public string? Error { get; }

    /// <summary>Creates a successful result.</summary>
    /// <returns>A successful <see cref="Result" />.</returns>
    public static Result Ok() => new(true, null);

    /// <summary>Creates a failed result containing the supplied error message.</summary>
    /// <param name="error">A message describing the failure.</param>
    /// <returns>A failed <see cref="Result" />.</returns>
    public static Result Fail(string error) => new(false, error);
}
