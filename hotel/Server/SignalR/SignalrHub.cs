using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hotel.Server.SignalR
{
    public class SignalrHub : Hub
    {
        public async Task SendPaymentResponse(PaymentResponseModel paymentResponse)
        {
            await Clients.All.SendAsync("BroadcastMessage", paymentResponse);
        }
        //await Clients.All.SendAsync("BroadcastMessage", paymentResponse);
        //private NavigationManager Navigation;
        //private HubConnection? hubConnection;
        //SignalrHub()
        //{
        //    hubConnection = new HubConnectionBuilder()
        //        .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
        //        .Build();

        //}
        //public async Task BroadcastMessage(PaymentResponseModel paymentResponse)
        //{
        //    //await Clients.All.
        //    await hubConnection.SendAsync()
        //}
    }
}
//await Clients.All.BroadcastMessage(paymentResponse);