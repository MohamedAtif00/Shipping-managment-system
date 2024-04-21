using Ardalis.Result;
using MediatR;

namespace Shipping_managment_system.Application.Abstraction
{
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, Result<TResult>>
         where TCommand : ICommand<TResult>
         where TResult : notnull
    {
    }

    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand,Result>
        where TCommand : ICommand
    {
    }
}
