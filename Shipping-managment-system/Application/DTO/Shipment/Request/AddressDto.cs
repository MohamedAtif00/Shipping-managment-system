namespace Shipping_managment_system.Application.DTO.Shipment.Request
{
    public record AddressDto(
                    string State,
                    string City,
                    double Lat,
                    double Lon,
                    string IsoCode,
                    string? HouseNumber,
                    string? PostCode,
                    string? Road,
                    string? Village
                );
}
