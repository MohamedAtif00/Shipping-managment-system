using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.AddressDomain;

namespace Shipping_managment_system.Domain.Repository
{
    public interface IAddressRepository : IGenericRepository<Address,AddressId>
    {
    }
}
