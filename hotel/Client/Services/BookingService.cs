
using Hotel.Client;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;


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
        
        public async Task CreateBooking(Booking Booking)
        {
            await _http.PostAsJsonAsync("api/Booking", Booking);
            
        }

        public async Task DeleteBooking(int id)
        {
            var result = await _http.DeleteAsync($"api/Booking/{id}");
            _navigationManger.NavigateTo("admin/Bookings");
        }

        public async Task<Booking?> GetBookingByFName(string fname)
        {
            var result = await _http.GetAsync($"api/Booking/name/{fname}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Booking>();
            }
            return null;
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

        public async Task UpdateBooking(int id, Booking Booking)
        {
            await _http.PutAsJsonAsync($"api/Booking/{id}", Booking);
            _navigationManger.NavigateTo("admin/Bookings");
        }
    }
}