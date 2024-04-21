using Shipping_managment_system.Application.CQRS.Shipment.AddShipment;

namespace Shipping_managment_system.Application.DTO.Shipment.Request
{
    public record CreateShipmentRequest(
                            string CargoType,
                            double Weight,
                            AddressDto StartLocation,
                            AddressDto EndLocation,
                            string Title,
                            string Description,
                            DateTime ShipmentDate,
                            Guid userId);
    
    
}
