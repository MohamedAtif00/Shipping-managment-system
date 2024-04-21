using Ardalis.Result;
using MediatR;

namespace Shipping_managment_system.Application.Abstraction
{
    public interface IQuery<T> :IRequest<Result<T>>
    {
    }
}
