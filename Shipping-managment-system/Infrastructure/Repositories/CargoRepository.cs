using Shipping_managment_system.Domain.Entity.CargoDomain;
using Shipping_managment_system.Domain.Repository;
using Shipping_managment_system.Infrastructure.Data;
using Shipping_managment_system.Infrastructure.DomainConfiguration;

namespace Shipping_managment_system.Infrastructure.Repositories
{
    public class CargoRepository : GenericRepository<Cargo, CargoId> ,ICargoRepository
    {
        public CargoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
