using Hotel.Shared.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Hotel.Client.Services
{
    public class StripePaymentService : IStripePaymentService

    {
        private readonly HttpClient _client;

        public StripePaymentService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> CheckOutCompleted(StripePaymentDTO? model)
        { 
            var result = await _client.PostAsJsonAsync("api/StripePayment/checkout",model );
            var url = await result.Content.ReadAsStringAsync();
            return url;
        }
    }
}
