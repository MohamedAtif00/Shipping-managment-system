using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.ShipmentDomain;

namespace Shipping_managment_system.Domain.Entity.CargoDomain
{
    public class Cargo : Entity<CargoId>
    {

        public Cargo() :base(CargoId.CreateUnique()) { }

        private Cargo(CargoId id, CargoType type, double distance, double fuelConsumption, double fuelCost, double cargoCost, double totalCost, double weight) : base(id)
        {
            CargoType = type;
            Distance = distance;
            FuelConsumption = fuelConsumption;
            FuelCost = fuelCost;
            CargoCost = cargoCost;
            TotalCost = totalCost;
            Weight = weight;
        }

        public CargoType CargoType { get;private set; }
        public double Distance { get; private set; } // in kilometers
        public double Weight { get; private set; }
        public double FuelConsumption { get; private set; } // in liters
        public double FuelCost { get; private set; } // in USD
        public double CargoCost { get; private set; } // in USD
        public double TotalCost { get; private set; } // in USD

        public static Cargo Create(string type,double distance, double fuelConsumption, double fuelCost, double cargoCost, double totalCost,double weight)
        {
            return new(CargoId.CreateUnique(),ConvertToCargoType(type), distance,fuelConsumption,fuelCost,cargoCost,totalCost,weight);
        }

        public void Update(CargoType type, double distance, double fuelConsumption, double fuelCost, double cargoCost, double totalCost)
        {
            CargoType = type;
            Distance = distance;
            FuelConsumption = fuelConsumption;
            FuelCost = fuelCost;
            CargoCost = cargoCost;
            TotalCost = totalCost;
        }

        public static CargoType ConvertToCargoType(string type)
        {
            return type switch
            {
                "Liquid" => CargoType.Liquid,
                "Solid" => CargoType.Solid,
                _ => CargoType.Other,
            };
        }


    }

    public enum CargoType
    {
        Liquid,
        Solid,
        Other
    }
}
