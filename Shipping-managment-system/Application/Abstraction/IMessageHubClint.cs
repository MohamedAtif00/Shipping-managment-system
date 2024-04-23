namespace Shipping_managment_system.Application.Abstraction
{
    public interface IMessageHubClint
    {
        Task SendOffersToUser(string message);
    }
}
