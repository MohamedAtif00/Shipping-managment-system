using Ardalis.Result;
using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.AddressDomain;
using addresses = Shipping_managment_system.Domain.Entity.AddressDomain.Address;

namespace Shipping_managment_system.Application.CQRS.Address.GetSingleAddress
{
    public class GetSingleAddressQueryHandler : IQueryHandler<GetSingleAddressQuery, addresses>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleAddressQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<addresses>> Handle(GetSingleAddressQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.AddressRepository.GetById(AddressId.Create(request.addressId));

                if (result == null) return Result.Error("this Address is not exist");

                return Result.Success(result);
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
