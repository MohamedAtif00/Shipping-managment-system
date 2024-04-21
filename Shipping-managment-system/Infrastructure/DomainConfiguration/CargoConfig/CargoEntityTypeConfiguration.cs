using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shipping_managment_system.Domain.Entity.CargoDomain;

namespace Shipping_managment_system.Infrastructure.DomainConfiguration.CargoConfig
{
    public class CargoEntityTypeConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(x =>x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.value, x => CargoId.Create(x));

            builder.Property(x => x.CargoType).HasConversion(x => x.ToString(), x => Enum.Parse<CargoType>(x));


        }
    }
}
