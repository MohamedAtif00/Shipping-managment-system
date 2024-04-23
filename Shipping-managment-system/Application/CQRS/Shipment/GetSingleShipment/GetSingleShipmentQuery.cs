using Shipping_managment_system.Application.Abstraction;
using shipments = Shipping_managment_system.Domain.Entity.ShipmentDomain.Shipment;


namespace Shipping_managment_system.Application.CQRS.Shipment.GetSingleShipment
{
    public record GetSingleShipmentQuery(Guid shipmentId):IQuery<shipments>;
    
    
}
