using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shipping_managment_system.Domain.Entity.AddressDomain;

namespace Shipping_managment_system.Infrastructure.DomainConfiguration.AddressConfig
{
    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>AddressId.Create(x));

        }
    }
}
