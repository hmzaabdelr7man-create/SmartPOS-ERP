namespace SmartPOS.Application.Common.Exceptions;

using FluentValidation;
using SmartPOS.Domain.Exceptions;

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

/// <summary>
/// Default implementation of <see cref="IExceptionHandler" /> that maps common exception types to user-facing error information.
/// </summary>
public class ExceptionHandler : IExceptionHandler
{
    /// <inheritdoc />
    public ErrorInfo Handle(Exception exception)
    {
        return exception switch
        {
            ValidationException validation => new ErrorInfo
            {
                Title = "Validation Failed",
                Message = string.Join(Environment.NewLine, validation.Errors.Select(e => e.ErrorMessage)),
                Severity = ErrorSeverity.Warning,
            },
            NotFoundException => new ErrorInfo
            {
                Title = "Not Found",
                Message = exception.Message,
                Severity = ErrorSeverity.Warning,
            },
            ForbiddenException => new ErrorInfo
            {
                Title = "Forbidden",
                Message = exception.Message,
                Severity = ErrorSeverity.Warning,
            },
            DomainException => new ErrorInfo
            {
                Title = "Domain Error",
                Message = exception.Message,
                Severity = ErrorSeverity.Error,
            },
            _ => new ErrorInfo
            {
                Title = "Unexpected Error",
                Message = exception.Message,
                Severity = ErrorSeverity.Critical,
            },
        };
    }
}
