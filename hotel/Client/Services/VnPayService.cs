using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace Hotel.Client.Services
{
    public class VnPayService : IVnPayService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;
        public VnPayService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }
        public async Task<string> CreatePaymentUrl(Payment model)
        {
            var response = await _http.PostAsJsonAsync("api/VNPAY/CreatePaymentUrl", model);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Read and return the content of the response as a string
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Handle the case where the status code is not OK
                // You might want to throw an exception, log, or handle it in some way
                // For now, returning null, but consider handling errors more gracefully
                return null;
            }
        }
    }
}
