using Ardalis.Result;
using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Domain.Abstraction;
using cargo = Shipping_managment_system.Domain.Entity.CargoDomain.Cargo;


namespace Shipping_managment_system.Application.CQRS.Cargo.GetAllCargos
{
    public class GetAllCargoQueryHandler : IQueryHandler<GetAllCargoQuery, List<cargo>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCargoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<cargo>>> Handle(GetAllCargoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.CargoRepository.GetAll();

                if (result == null) return Result.Error("error");

                return Result.Success(result);
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
