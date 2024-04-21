namespace Shipping_managment_system.Domain.Abstraction
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
