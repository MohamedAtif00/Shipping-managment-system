using Microsoft.EntityFrameworkCore;
using Shipping_managment_system.Domain.Entity.refreshTokenDomain;
using Shipping_managment_system.Domain.Repository;
using Shipping_managment_system.Infrastructure.Data;
using Shipping_managment_system.Infrastructure.DomainConfiguration;

namespace Shipping_managment_system.Infrastructure.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken, RefreshTokenId>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<RefreshToken> GetRefreshTokenByUserId(Guid userId)
        {
            return await _context.refreshTokens.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<RefreshToken> FindByToken(string token)
        {
            return await _context.refreshTokens.Where(x => x.Token == token).FirstOrDefaultAsync();
        }
    }
}
