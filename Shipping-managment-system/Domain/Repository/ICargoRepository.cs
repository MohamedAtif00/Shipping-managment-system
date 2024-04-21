using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.CargoDomain;

namespace Shipping_managment_system.Domain.Repository
{
    public interface ICargoRepository :IGenericRepository<Cargo,CargoId>
    {
    }
}
