using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.ShipmentDomain;

namespace Shipping_managment_system.Domain.Repository
{
    public interface IShipmentRepository :IGenericRepository<Shipment,ShipmentId>
    {
    }
}
