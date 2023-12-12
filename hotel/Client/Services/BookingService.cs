
using Hotel.Client;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

using System.Text;
using System.Threading.Tasks;
namespace Hotel.Client.Services
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public BookingService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
        //public List<Payment> Payment { get; set; } = new List<Payment>();


        public async Task CreateBooking(Booking Booking)
        {
            await _http.PostAsJsonAsync("api/Booking", Booking);

        }

        public async Task DeleteBooking(int id)
        {
            var result = await _http.DeleteAsync($"api/Booking/{id}");

        }

        public async Task<Booking?> GetBookingById(int id)
        {
            var result = await _http.GetAsync($"api/Booking/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Booking>();
            }
            return null;
        }

        public async Task GetBookings()
        {
            var result = await _http.GetFromJsonAsync<List<Booking>>("api/Booking");
            if (result is not null)
                Bookings = result;
        }

        //public async Task<int?> GetCostById(int id)
        //{
        //    var result = await _http.GetAsync($"api/Booking/payment/{id}");
        //    if (result.StatusCode == HttpStatusCode.OK)
        //    {
        //        return await result.Content.ReadFromJsonAsync<int>();
        //    }
        //    return null;
        //}

        public async Task UpdateBooking(int id, Booking Booking)
        {
            await _http.PutAsJsonAsync($"api/Booking/{id}", Booking);

        }
        //public async Task<Booking> PaymentSuccessful(Booking details)
        //{
        //    //Serialise
        //    var content = JsonConvert.SerializeObject(details);
        //    var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
        //    var response = await _http.PostAsync("api/Payment/paymentsuccessful", bodyContent);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var contentTemp = await response.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<Booking>(contentTemp);
        //        return result;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public async Task GetPayments()
        //{
        //    var result = await _http.GetFromJsonAsync<List<Payment>>("api/Payment");
        //    if (result is not null)
        //        Payment = result;
        //}

        //public async Task CreatePayment(Payment Payment,int Bid)
        //{
        //    await _http.PostAsJsonAsync($"api/Payment/{Bid}", Payment);
        //}

        //public async Task UpdatePayment(int id, Payment payment)
        //{
        //    await _http.PutAsJsonAsync($"api/Payment/{id}", payment);
        //    _navigationManger.NavigateTo("admin/Payments");
        //}
    }
}