namespace SmartPOS.Application.CQRS.Behaviors;

using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

/// <summary>
/// A pipeline behavior that validates requests using all matching FluentValidation validators before forwarding the request.
/// </summary>
/// <typeparam name="TRequest">The type of the request being validated.</typeparam>
/// <typeparam name="TResponse">The type of the response produced by the request.</typeparam>
public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly ILogger<ValidationPipelineBehavior<TRequest, TResponse>> _logger;

    /// <summary>Initializes a new instance of the <see cref="ValidationPipelineBehavior{TRequest, TResponse}" /> class.</summary>
    /// <param name="validators">The validators applicable to the request type.</param>
    /// <param name="logger">The logger used to record validation failures.</param>
    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationPipelineBehavior<TRequest, TResponse>> logger)
    {
        _validators = validators;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next().ConfigureAwait(false);
        }

        var context = new ValidationContext<TRequest>(request);
        var failures = (await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken))).ConfigureAwait(false))
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .ToList();

        if (failures.Count != 0)
        {
            _logger.LogWarning("Validation failed for {RequestType}: {Failures}", typeof(TRequest).Name, string.Join(", ", failures.Select(f => f.ErrorMessage)));
            throw new ValidationException(failures);
        }

        return await next().ConfigureAwait(false);
    }
}
