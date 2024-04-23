namespace Shipping_managment_system.Application.DTO.Shipment.Request
{
    public record GetTotalPriceRequest(string CargoType,
                                    double Weight,
                                    AddressDto StartLocation,
                                    AddressDto EndLocation);
    
    
}
