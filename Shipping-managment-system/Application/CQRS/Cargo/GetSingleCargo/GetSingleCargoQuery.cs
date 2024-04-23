using Shipping_managment_system.Application.Abstraction;
using cargo = Shipping_managment_system.Domain.Entity.CargoDomain.Cargo;


namespace Shipping_managment_system.Application.CQRS.Cargo.GetSingleCargo
{
    public record GetSingleCargoQuery(Guid cargoId) :IQuery<cargo>;
    
    
}
