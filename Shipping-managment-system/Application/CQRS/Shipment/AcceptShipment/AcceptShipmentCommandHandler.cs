using Ardalis.Result;
using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.ShipmentDomain;

namespace Shipping_managment_system.Application.CQRS.Shipment.AcceptShipment
{
    public class AcceptShipmentCommandHandler : ICommandHandler<AcceptShipementCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AcceptShipmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(AcceptShipementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var shipment = await _unitOfWork.ShipmentRepository.GetById(ShipmentId.Create(request.id));

                if (shipment == null) return Result.Error("shipment is not exist");

                shipment.ShipmentStart();

                var result = await _unitOfWork.ShipmentRepository.Update(shipment);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("no changes");

                return Result.Success(true);

            }catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
