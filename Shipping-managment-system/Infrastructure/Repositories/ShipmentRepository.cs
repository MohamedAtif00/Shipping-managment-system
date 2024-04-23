using Microsoft.EntityFrameworkCore;
using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.ShipmentDomain;
using Shipping_managment_system.Domain.Repository;
using Shipping_managment_system.Infrastructure.Data;
using Shipping_managment_system.Infrastructure.DomainConfiguration;

namespace Shipping_managment_system.Infrastructure.Repositories
{
    public class ShipmentRepository : GenericRepository<Shipment, ShipmentId>,IShipmentRepository
    {
        public ShipmentRepository(ApplicationDbContext context) : base(context)
        {
        }

       
    }
}
