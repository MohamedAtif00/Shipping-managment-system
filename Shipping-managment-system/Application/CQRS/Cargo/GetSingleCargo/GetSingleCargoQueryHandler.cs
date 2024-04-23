using Ardalis.Result;
using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Application.CQRS.Address.GetSingleAddress;
using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.CargoDomain;
using cargo = Shipping_managment_system.Domain.Entity.CargoDomain.Cargo;


namespace Shipping_managment_system.Application.CQRS.Cargo.GetSingleCargo
{
    public class GetSingleCargoQueryHandler : IQueryHandler<GetSingleCargoQuery, cargo>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleCargoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<cargo>> Handle(GetSingleCargoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.CargoRepository.GetById(CargoId.Create(request.cargoId));

                if (result == null) return Result.Error("Error");

                return Result.Success(result);
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
