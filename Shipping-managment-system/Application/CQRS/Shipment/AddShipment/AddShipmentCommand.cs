using Ardalis.Result;
using MediatR;
using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Application.DTO.Shipment.Request;
using Shipping_managment_system.Domain.Entity.CargoDomain;

namespace Shipping_managment_system.Application.CQRS.Shipment.AddShipment
{
    public record AddShipmentCommand(
                            string CargoType,
                            double weight,
                            AddressDto StartLocation,
                            AddressDto EndLocation,
                            string Title,
                            string Description,
                            DateTime ShipmentDate,
                            Guid userId
                        ) : ICommand;


}
