using Hotel.Shared.Models;

namespace Hotel.Server.SignalR
{
    public interface IHubClient
    {
        Task BroadcastMessage(PaymentResponseModel paymentResponse);
    }
}
