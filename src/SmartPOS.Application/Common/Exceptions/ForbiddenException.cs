namespace SmartPOS.Application.Common.Exceptions;

/// <summary>
/// The exception that is thrown when the current user is not permitted to perform an operation.
/// </summary>
public class ForbiddenException : ApplicationException
{
    /// <summary>Initializes a new instance of the <see cref="ForbiddenException" /> class with a specified error message.</summary>
    /// <param name="message">The message that describes the error.</param>
    public ForbiddenException(string message)
        : base(message)
    {
    }
}
