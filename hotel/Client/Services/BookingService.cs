
using Hotel.Client;
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

        public async Task<List<Booking>> GetBookings()
        {
            var options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };
            var result = await _http.GetFromJsonAsync<List<Booking>>("api/Booking",options);
            if (result is not null)
                Bookings = result;
            return Bookings;
        }

        public async Task<Booking?> GetBookingById(int id)
        {
            var options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            var result = await _http.GetAsync($"api/Booking/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Booking>(options);
            }
            return null;
        }

        public async Task<List<Booking>> SearchBookings(string searchText)
        {
            var options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            var result = await _http.GetAsync($"api/Booking/search/{searchText}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<List<Booking?>>(options);
            }
            return null;
        }

        public async Task<int?> GetCostById(int id)
        {

            var result = await _http.GetAsync($"api/Booking/payment/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<int>();
            }
            return null;
        }
        public async Task CreateBooking(Booking Booking)
        {
            await _http.PostAsJsonAsync("api/Booking", Booking);

        }

        public async Task UpdateBooking(int id, Booking Booking)
        {
            await _http.PutAsJsonAsync($"api/Booking/{id}", Booking);
            

        }
        public async Task<List<Booking>> SearchBookings(string searchText)
        {
            var options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            var result = await _http.GetAsync($"api/Booking/search/{searchText}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<List<Booking?>>(options);
            }
            return null;
        }
        public async Task<List<Booking>> SearchBookingsByGid(int gid)
        {
            var options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            var result = await _http.GetAsync($"api/Booking/searchGid/{gid}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<List<Booking?>>(options);
            }
            return null;
        }
        public async Task DeleteBooking(int id)
        {
            var result = await _http.DeleteAsync($"api/Booking/{id}");
            _navigationManger.NavigateTo("admin/bookings");
        }
    }
}