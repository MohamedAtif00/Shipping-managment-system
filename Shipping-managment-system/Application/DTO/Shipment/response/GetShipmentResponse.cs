using Shipping_managment_system.Domain.Entity.AddressDomain;
using Shipping_managment_system.Domain.Entity.CargoDomain;

namespace Shipping_managment_system.Application.DTO.Shipment.response
{
    public class GetShipmentResponse
    {

        public string Title;

        public GetShipmentResponse(string title, string description, string status, DateTime shipmentDate, DateTime creationDate, Guid userId, Address startLocation, Address endLocation, Cargo cargo)
        {
            Title = title;
            Description = description;
            Status = status;
            ShipmentDate = shipmentDate;
            CreationDate = creationDate;
            this.userId = userId;
            StartLocation = startLocation;
            EndLocation = endLocation;
            Cargo = cargo;
        }

        public string Description;
        public string Status;
        public DateTime ShipmentDate;
        public DateTime CreationDate;
        public Address StartLocation;
        public Address EndLocation;
        public Cargo Cargo;

        public Guid userId;
    }
}
