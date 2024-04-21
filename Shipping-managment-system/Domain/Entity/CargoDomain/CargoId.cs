using Shipping_managment_system.Domain.Abstraction;

namespace Shipping_managment_system.Domain.Entity.CargoDomain
{
    public class CargoId : ValueObjectId
    {
        protected CargoId(Guid id) : base(id)
        {
        }

        public static CargoId Create(Guid id)
        {
            return new(id);
        }

        public static CargoId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}