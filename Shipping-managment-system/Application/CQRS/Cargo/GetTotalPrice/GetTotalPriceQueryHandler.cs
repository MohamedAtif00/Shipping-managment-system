using Ardalis.Result;
using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Application.DTO.Shipment.Request;
using Shipping_managment_system.Domain.Abstraction;
using cargo = Shipping_managment_system.Domain.Entity.CargoDomain.Cargo;

namespace Shipping_managment_system.Application.CQRS.Cargo.GetTotalPrice
{
    public class GetTotalPriceQueryHandler : IQueryHandler<GetTotalPriceQuery, double>
    {

        private const double FuelEfficiency = 10; // in liters per 100 km
        private const double FuelCostPerLiter = 1.5; // in USD
        private const double CargoWeight = 1000; // in kg
        public async Task<Result<double>> Handle(GetTotalPriceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Calculate distance
                var distance = CalculateDistance(request.StartLocation, request.EndLocation);

                // Calculate fuel consumption
                var fuelConsumption = (distance / 100) * FuelEfficiency;

                // Calculate fuel cost
                var fuelCost = fuelConsumption * FuelCostPerLiter;

                // Calculate cargo cost
                var cargoCost = CalculateCargoCost(request.StartLocation, request.EndLocation);

                // Calculate total cost
                var totalCost = fuelCost + cargoCost;

                return Result.Success(totalCost);
            }catch (Exception ex)
            {
                return  Result.CriticalError("System Error");
            }
        }

        private double CalculateCargoCost(AddressDto startLocation, AddressDto endLocation)
        {
            // Assuming the cost is $0.1 per kg per km
            const double cargoCostPerKm = 0.1;
            var distance = CalculateDistance(startLocation, endLocation);
            return distance * CargoWeight * cargoCostPerKm;
        }

        private double CalculateDistance(AddressDto startLocation, AddressDto endLocation)
        {
            const double R = 6371; // Radius of the earth in km
            var dLat = Deg2rad(endLocation.Lat - startLocation.Lat);
            var dLon = Deg2rad(endLocation.Lon - startLocation.Lon);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(Deg2rad(startLocation.Lat)) * Math.Cos(Deg2rad(endLocation.Lat)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c; // Distance in km
            return d;
        }

        private double Deg2rad(double deg)
        {
            return deg * (Math.PI / 180);
        }
    }
}
