using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace Hotel.Client.Services
{
    public class PaymentService : IPaymentService
    {
        public List<Payment?> Payments { get; set; } = new List<Payment>();
     

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public PaymentService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }

       
        public async Task<Booking> PaymentSuccessful(Booking details)
        {
            //Serialise
            var content = JsonConvert.SerializeObject(details);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("api/Payment/paymentsuccessful", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Booking>(contentTemp);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Payment>> GetPayments()
        {
            var options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            var result = await _http.GetFromJsonAsync<List<Payment>>("api/Payment/get", options);
            if (result is not null)
                Payments = result;
            return Payments;
        }

        public async Task CreatePayment(Payment Payment)
        {
            await _http.PostAsJsonAsync($"api/Payment/create", Payment);
        }

        public async Task UpdatePayment(int id, Payment payment)
        {
            await _http.PutAsJsonAsync($"api/Payment/update/{id}", payment);
            
        }

        public async Task<Payment?> GetCostById(int id)
        {
            var result = await _http.GetAsync($"api/Payment/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Payment>();
            }
            return null;
        }
    }
}
