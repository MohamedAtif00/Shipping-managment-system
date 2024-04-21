using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shipping_managment_system.Domain.Entity.AddressDomain;
using Shipping_managment_system.Domain.Entity.CargoDomain;
using Shipping_managment_system.Domain.Entity.ShipmentDomain;
using Shipping_managment_system.Infrastructure.DomainConfiguration.CargoConfig;

namespace Shipping_managment_system.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {
            
        }

        public DbSet<Shipment> shipments { get; set; }
        public DbSet<Cargo> cargos { get; set; }
        public DbSet<Address> addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
