using Shipping_managment_system.Application.Abstraction;
using cargo = Shipping_managment_system.Domain.Entity.CargoDomain.Cargo;

namespace Shipping_managment_system.Application.CQRS.Cargo.GetAllCargos
{
    public record GetAllCargoQuery() : IQuery<List<cargo>>;
    
    
}
