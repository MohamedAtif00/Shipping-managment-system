using Shipping_managment_system.Application.Abstraction;

namespace Shipping_managment_system.Application.CQRS.Shipment.AcceptShipment
{
    public record AcceptShipementCommand(Guid id) :ICommand<bool>;
   
    
}
