using Ardalis.Result;
using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.ShipmentDomain;
using shipments = Shipping_managment_system.Domain.Entity.ShipmentDomain.Shipment;


namespace Shipping_managment_system.Application.CQRS.Shipment.GetSingleShipment
{
    public class GetSingleShipmentQueryHandler : IQueryHandler<GetSingleShipmentQuery, shipments>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleShipmentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<shipments>> Handle(GetSingleShipmentQuery request, CancellationToken cancellationToken)
        {
            try {
                var single = await _unitOfWork.ShipmentRepository.GetById(ShipmentId.Create(request.shipmentId));

                if (single == null) return Result.Error("shipment is not exist");

                return Result.Success(single);
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
