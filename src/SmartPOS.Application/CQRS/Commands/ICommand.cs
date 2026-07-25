namespace SmartPOS.Application.CQRS.Commands;

using MediatR;
using SmartPOS.Application.Common;

/// <summary>
/// Marks a command that returns a value of type <typeparamref name="TResponse" />.
/// </summary>
/// <typeparam name="TResponse">The type of the value returned by the command.</typeparam>
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}

/// <summary>
/// Marks a command that does not return a value.
/// </summary>
public interface ICommand : IRequest<Result>
{
}
