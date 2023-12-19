using Hotel.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace Hotel.Server.SignalR
{
    public class SignalrHub : Hub<IHubClient>
    {
        public async Task BroadcastMessage(PaymentResponseModel paymentResponse)
        {
            await Clients.All.BroadcastMessage(paymentResponse);
        }
    }
}
