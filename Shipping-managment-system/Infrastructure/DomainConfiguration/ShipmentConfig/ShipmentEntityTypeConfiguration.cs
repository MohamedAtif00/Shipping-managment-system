using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shipping_managment_system.Domain.Entity.AddressDomain;
using Shipping_managment_system.Domain.Entity.CargoDomain;
using Shipping_managment_system.Domain.Entity.ShipmentDomain;

namespace Shipping_managment_system.Infrastructure.DomainConfiguration.ShipmentConfig
{
    public class ShipmentEntityTypeConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.value, x => ShipmentId.Create(x));

            builder.Property(x => x.CargoId).HasConversion(x => x.value, x => CargoId.Create(x));

            builder.Property(x => x.StartLocation).HasConversion(x => x.value, x => AddressId.Create(x));
            builder.Property(x => x.EndLocation).HasConversion(x => x.value, x => AddressId.Create(x));

        }

            
    }
}
