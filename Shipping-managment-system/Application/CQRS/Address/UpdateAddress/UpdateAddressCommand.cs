using Shipping_managment_system.Application.Abstraction;

namespace Shipping_managment_system.Application.CQRS.Address.UpdateAddress
{
    public record UpdateAddressCommand(Guid addressId,string state,string city,double lat,double lon,string isoCode,string houseNumber,string postCode,string road,string village) : ICommand<bool>;
}

