namespace SmartPOS.Contracts.Errors;

/// <summary>
/// Defines the severity of an error reported to the user interface.
/// </summary>
public enum ErrorSeverity
{
    /// <summary>An informational message that does not represent a failure.</summary>
    Information,

    /// <summary>A warning that an operation completed with caveats.</summary>
    Warning,

    /// <summary>An error that prevented an operation from completing.</summary>
    Error,

    /// <summary>A critical error that compromises application integrity.</summary>
    Critical,
}

/// <summary>
/// Describes an error that should be presented to the user.
/// </summary>
public sealed class ErrorInfo
{
    /// <summary>Gets or sets the short title of the error.</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>Gets or sets the detailed message of the error.</summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>Gets or sets the severity of the error.</summary>
    public ErrorSeverity Severity { get; set; } = ErrorSeverity.Error;
}

/// <summary>
/// Defines a service that translates exceptions into user-facing <see cref="ErrorInfo" /> instances.
/// </summary>
public interface IExceptionHandler
{
    /// <summary>Maps the supplied exception to an <see cref="ErrorInfo" /> instance.</summary>
    /// <param name="exception">The exception to translate.</param>
    /// <returns>An <see cref="ErrorInfo" /> describing the exception.</returns>
    ErrorInfo Handle(Exception exception);
}
