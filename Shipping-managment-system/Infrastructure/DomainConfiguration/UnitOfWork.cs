using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Repository;
using Shipping_managment_system.Infrastructure.Data;

namespace Shipping_managment_system.Infrastructure.DomainConfiguration
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public UnitOfWork(ApplicationDbContext applicationDbContext, IShipmentRepository shipmentRepository, ICargoRepository cargoRepository, IAddressRepository addressRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            _applicationDbContext = applicationDbContext;
            ShipmentRepository = shipmentRepository;
            CargoRepository = cargoRepository;
            AddressRepository = addressRepository;
            RefreshTokenRepository = refreshTokenRepository;
        }

        public IShipmentRepository ShipmentRepository { get; }

        public ICargoRepository CargoRepository { get; }

        public IAddressRepository AddressRepository { get; }
        public IRefreshTokenRepository RefreshTokenRepository { get; }
       

        public async Task<int> save()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
