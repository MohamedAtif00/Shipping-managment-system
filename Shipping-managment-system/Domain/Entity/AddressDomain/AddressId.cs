using Shipping_managment_system.Domain.Abstraction;

namespace Shipping_managment_system.Domain.Entity.AddressDomain
{
    public class AddressId : ValueObjectId
    {
        protected AddressId(Guid id) : base(id)
        {
        }

        public static AddressId Create(Guid id)
        {
            return new(id);
        }

        public static AddressId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}
