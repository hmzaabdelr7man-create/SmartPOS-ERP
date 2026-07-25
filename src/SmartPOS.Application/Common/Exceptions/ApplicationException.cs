namespace SmartPOS.Application.Common.Exceptions;

/// <summary>
/// The base exception thrown by the application layer when an operation cannot be completed.
/// </summary>
public class ApplicationException : Exception
{
    /// <summary>Initializes a new instance of the <see cref="ApplicationException" /> class with a specified error message.</summary>
    /// <param name="message">The message that describes the error.</param>
    public ApplicationException(string message)
        : base(message)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ApplicationException" /> class with a specified error message and a reference to the inner exception that caused this exception.</summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public ApplicationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
