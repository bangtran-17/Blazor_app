
using Hotel.Client;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hotel.Client.Services
{
    public class RoomtypeService : IRoomtypeService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public RoomtypeService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }

        public List<Roomtype> Roomtypes { get; set; } = new List<Roomtype>();

        public async Task CreateRoomtype(Roomtype Roomtype)
        {
            await _http.PostAsJsonAsync("api/Roomtype", Roomtype);

        }

        public async Task DeleteRoomtype(int id)
        {
            var result = await _http.DeleteAsync($"api/Roomtype/{id}");

        }


        public async Task<Roomtype?> GetRoomtypeById(int id)
        {
            var options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };
            var result = await _http.GetAsync($"api/Roomtype/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Roomtype>(options);
            }
            return null;
        }

        public async Task<List<Roomtype>> GetRoomtypes()
        {
            var options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };
            Roomtypes= await _http.GetFromJsonAsync<List<Roomtype>>("api/Roomtype",options);
            return Roomtypes;

        }
        public async Task UpdateRoomtype(int id, Roomtype Roomtype)
        {
            await _http.PutAsJsonAsync($"api/Roomtype/{id}", Roomtype);

        }
    }
}