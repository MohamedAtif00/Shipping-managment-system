using Shipping_managment_system.Application.Abstraction;

namespace Shipping_managment_system.Application.CQRS.Cargo.GetTotalPrice
{
    public record GetTotalPriceQuery( ):IQuery<double>;
    
    
}
