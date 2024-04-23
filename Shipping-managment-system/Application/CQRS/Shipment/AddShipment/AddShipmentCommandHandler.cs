using Ardalis.Result;
using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Application.DTO.Shipment.Request;
using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.AddressDomain;
using Shipping_managment_system.Domain.Entity.CargoDomain;
using Shipping_managment_system.Domain.Entity.ShipmentDomain;
using shipments = Shipping_managment_system.Domain.Entity.ShipmentDomain.Shipment;
using Addresses = Shipping_managment_system.Domain.Entity.AddressDomain.Address;
using Cargoo = Shipping_managment_system.Domain.Entity.CargoDomain.Cargo;

namespace Shipping_managment_system.Application.CQRS.Shipment.AddShipment
{
    public class AddShipmentCommandHandler : ICommandHandler<AddShipmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private const double FuelEfficiency = 10; // in liters per 100 km
        private const double FuelCostPerLiter = 1.5; // in USD
        private const double CargoWeight = 1000; // in kg

        public AddShipmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddShipmentCommand request, CancellationToken cancellationToken)
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

                // Create Cargo
                var cargo = Cargoo.Create(request.CargoType, distance, fuelConsumption, fuelCost, cargoCost, totalCost,request.weight);

                // Add Cargo 
                await _unitOfWork.CargoRepository.Add(cargo);

                // Create Addresses
                var addressOne = Addresses.Create(request.StartLocation.State, request.StartLocation.City, request.StartLocation.Lat, request.StartLocation.Lon, request.StartLocation.IsoCode, request.StartLocation.HouseNumber, request.StartLocation.PostCode, request.StartLocation.Road, request.StartLocation.Village,request.StartLocation.LocationName);
                var addressTwo = Addresses.Create(request.EndLocation.State, request.EndLocation.City, request.EndLocation.Lat, request.EndLocation.Lon, request.EndLocation.IsoCode, request.EndLocation.HouseNumber, request.EndLocation.PostCode, request.EndLocation.Road, request.EndLocation.Village,request.EndLocation.LocationName);

                // Add the addresses to the database
                await _unitOfWork.AddressRepository.Add(addressOne);
                await _unitOfWork.AddressRepository.Add(addressTwo);

                // Assign the generated Ids to the shipment
                var shipment = shipments.Create(addressOne.Id, addressTwo.Id,cargo, request.Title, request.Description, request.ShipmentDate, request.userId);

                // Add the shipment to the database
                await _unitOfWork.ShipmentRepository.Add(shipment);

                // Save changes to the database
                await _unitOfWork.save();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.CriticalError(ex.Message);
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
