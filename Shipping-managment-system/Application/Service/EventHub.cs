using Microsoft.AspNetCore.SignalR;
using Shipping_managment_system.Application.Abstraction;

namespace Shipping_managment_system.Application.Service
{
    public class EventHub:Hub<IMessageHubClint>
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendOffersToUser(message);
        }
    }
}
