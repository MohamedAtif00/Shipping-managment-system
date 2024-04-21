using Shipping_managment_system.Domain.Abstraction;

namespace Shipping_managment_system.Domain.Entity.ShipmentDomain
{
    public class ShipmentId : ValueObjectId
    {
        protected ShipmentId(Guid id) : base(id)
        {
        }

        public static ShipmentId Create(Guid id)
        {
            return new(id);
        }

        public static ShipmentId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}