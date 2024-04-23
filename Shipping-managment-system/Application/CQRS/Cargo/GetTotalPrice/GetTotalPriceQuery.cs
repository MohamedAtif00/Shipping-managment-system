using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Application.DTO.Shipment.Request;

namespace Shipping_managment_system.Application.CQRS.Cargo.GetTotalPrice
{
    public record GetTotalPriceQuery(string CargoType,
                                    double Weight,
                                    AddressDto StartLocation,
                                    AddressDto EndLocation) :IQuery<double>;
    
    
}
