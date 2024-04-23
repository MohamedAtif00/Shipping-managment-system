using Ardalis.Result;
using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Domain.Abstraction;
using addresses = Shipping_managment_system.Domain.Entity.AddressDomain.Address;


namespace Shipping_managment_system.Application.CQRS.Address.GetAllAddress
{
    public class GetAllAddressQueryHandler : IQueryHandler<GetAllAddressQuery, List<addresses>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAddressQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<addresses>>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.AddressRepository.GetAll();

                if (result == null) return Result.Error("Error");

                return Result.Success(result);
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
