using Ardalis.Result;
using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Domain.Abstraction;
using shipments = Shipping_managment_system.Domain.Entity.ShipmentDomain.Shipment;



namespace Shipping_managment_system.Application.CQRS.Shipment.GetAllShipments
{
    public class GetAllShipmentQueryHandler : IQueryHandler<GetAllShipmentQuery, List<shipments>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllShipmentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<shipments>>> Handle(GetAllShipmentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var all = await _unitOfWork.ShipmentRepository.GetAll();

                if (all == null) return Result.Error("error");

                return Result.Success(all);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
