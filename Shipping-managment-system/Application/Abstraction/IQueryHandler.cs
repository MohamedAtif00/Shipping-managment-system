using Ardalis.Result;
using MediatR;

namespace Shipping_managment_system.Application.Abstraction
{
    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery,Result<TResult>>
        where TQuery : IQuery<TResult>
        where TResult : notnull
    {
    }
}
