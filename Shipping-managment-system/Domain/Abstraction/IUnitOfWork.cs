using Shipping_managment_system.Domain.Repository;

namespace Shipping_managment_system.Domain.Abstraction
{
    public interface IUnitOfWork
    {
        IShipmentRepository ShipmentRepository { get; }
        ICargoRepository CargoRepository { get; }
        IAddressRepository AddressRepository { get; }

        Task<int> save();
    }
}
