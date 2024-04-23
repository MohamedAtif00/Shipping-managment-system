using Ardalis.Result;
using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Domain.Abstraction;
using Shipping_managment_system.Domain.Entity.AddressDomain;

namespace Shipping_managment_system.Application.CQRS.Address.UpdateAddress
{
    public class UpdateAddressCommandHandler : ICommandHandler<UpdateAddressCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAddressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var address = await _unitOfWork.AddressRepository.GetById(AddressId.Create(request.addressId));

                address.Update(request.state,request.city,request.lat,request.lon,request.isoCode,request.houseNumber,request.postCode,request.road,request.village);

                var result = await _unitOfWork.AddressRepository.Update(address);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("Nothng changed");

                return Result.Success(true);
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
