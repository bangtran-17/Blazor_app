using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using Hotel.Shared.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Hotel.Client.Services
{
    public interface IHubClient
    {
        event Action<PaymentResponseModel> OnPaymentResponse;

        Task StartConnection();
    }

    public class HubClient : IHubClient
    {
        private readonly HubConnection _hubConnection;

        public event Action<PaymentResponseModel> OnPaymentResponse;

        public HubClient(NavigationManager navigationManager)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri("/paymentHub"))
                .Build();

            _hubConnection.On<PaymentResponseModel>("BroadcastMessage", BroadcastMessageAsync);
        }

        public async Task StartConnection()
        {
            await _hubConnection.StartAsync();
        }

        private void BroadcastMessageAsync(PaymentResponseModel paymentResponse)
        {
            OnPaymentResponse?.Invoke(paymentResponse);
        }
    }

}
