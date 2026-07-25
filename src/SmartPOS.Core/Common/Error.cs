namespace SmartPOS.Core.Common;

/// <summary>
/// Describes a failure that occurred during an operation.
/// </summary>
public sealed class Error
{
    /// <summary>Initializes a new instance of the <see cref="Error" /> class with the supplied message.</summary>
    /// <param name="message">A human-readable description of the failure.</param>
    public Error(string message)
    {
        Message = message;
    }

    /// <summary>Gets a human-readable description of the failure.</summary>
    public string Message { get; }

    /// <summary>Gets a value indicating whether the error represents an empty (successful) state.</summary>
    public bool IsEmpty => string.IsNullOrEmpty(Message);

    /// <summary>Creates an empty error representing no failure.</summary>
    /// <returns>An empty <see cref="Error" />.</returns>
    public static Error None() => new(string.Empty);

    /// <summary>Returns the message describing the failure.</summary>
    /// <returns>The error message.</returns>
    public override string ToString() => Message;
}
