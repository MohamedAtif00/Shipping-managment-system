using Shipping_managment_system.Domain.Entity.AddressDomain;
using Shipping_managment_system.Domain.Repository;
using Shipping_managment_system.Infrastructure.Data;
using Shipping_managment_system.Infrastructure.DomainConfiguration;

namespace Shipping_managment_system.Infrastructure.Repositories
{
    public class AddressRepository : GenericRepository<Address, AddressId>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
