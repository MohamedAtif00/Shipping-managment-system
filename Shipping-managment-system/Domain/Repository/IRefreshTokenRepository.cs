using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.refreshTokenDomain;

namespace Shipping_managment_system.Domain.Repository
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken, RefreshTokenId>
    {
        Task<RefreshToken> FindByToken(string token);
        Task<RefreshToken> GetRefreshTokenByUserId(Guid userId);
    }
}
