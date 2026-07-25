namespace SmartPOS.Application.CQRS.Queries;

using MediatR;

/// <summary>
/// Marks a query that returns a value of type <typeparamref name="TResponse" />.
/// </summary>
/// <typeparam name="TResponse">The type of the value returned by the query.</typeparam>
public interface IQuery<TResponse> : IRequest<TResponse>
{
}
