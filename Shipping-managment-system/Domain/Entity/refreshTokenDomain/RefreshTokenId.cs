using Shipping_managment_system.Domain.Abstraction;

namespace Shipping_managment_system.Domain.Entity.refreshTokenDomain
{
    public class RefreshTokenId : ValueObjectId
    {
        protected RefreshTokenId(Guid id) : base(id)
        {
        }

        public static RefreshTokenId Create(Guid id)
        {
            return new(id);
        }
            
        public static RefreshTokenId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}