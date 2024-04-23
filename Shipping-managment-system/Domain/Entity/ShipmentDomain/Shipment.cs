using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.AddressDomain;
using Shipping_managment_system.Domain.Entity.CargoDomain;

namespace Shipping_managment_system.Domain.Entity.ShipmentDomain
{
    public class Shipment : Entity<ShipmentId>
    {
        public Shipment(ShipmentId id, AddressId startLocation, AddressId endLocation, CargoId cargoId, string title, string description, DateTime shipmentDate, Guid userId) : base(id)
        {
            StartLocation = startLocation;
            EndLocation = endLocation;
            CargoId = cargoId;
            Title = title;
            Description = description;
            ShipmentDate = shipmentDate;
            this.userId = userId;
        }
        public string Title { get;private set; }
        public string Description { get; private set; }
        public string Status { get; private set; } = "pending";
        public DateTime ShipmentDate { get; private set; }
        public DateTime CreationDate { get; private init; } = DateTime.UtcNow;
        public AddressId? StartLocation { get; private set; }
        public AddressId?  EndLocation { get; private set; }

        public Guid userId { get; private set; }


        public Cargo Cargo { get; private set; }
        public CargoId CargoId { get; private set; }



        public static Shipment Create(AddressId startLocation, AddressId endLocation, Cargo cargo,string title,string description,DateTime shipmentDate,Guid userId)
        {
            return new(ShipmentId.CreateUnique(),startLocation,endLocation,cargo.Id,title,description,shipmentDate,userId);
        }

        public void Update(string title,string description,DateTime shipmentDate)
        {
            Title = title;
            Description = description;
            ShipmentDate = shipmentDate;
        }

        public void ShipmentStart()
        {
            Status = "In Transit";
        }

        public void ShipmentFininshed()
        {
            Status = "Delivered";
        }
    }

    
}
