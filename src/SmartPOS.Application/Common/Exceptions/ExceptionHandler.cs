namespace SmartPOS.Application.Common.Exceptions;

using FluentValidation;
using SmartPOS.Contracts.Errors;
using SmartPOS.Domain.Exceptions;

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
