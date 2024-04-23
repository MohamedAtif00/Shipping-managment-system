using Shipping_managment_system.Application.Abstraction;
using addresses = Shipping_managment_system.Domain.Entity.AddressDomain.Address;


namespace Shipping_managment_system.Application.CQRS.Address.GetSingleAddress
{
    public record GetSingleAddressQuery(Guid addressId) : IQuery<addresses>;
    
    
}
