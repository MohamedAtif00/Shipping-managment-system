using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shipping_managment_system.Domain.Entity.refreshTokenDomain;

namespace Shipping_managment_system.Infrastructure.DomainConfiguration.RefreshtokenConfig
{
    public class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.value, x => RefreshTokenId.Create(x));


        }
    }
}
