
using Hotel.Client;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;


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
            _navigationManger.NavigateTo("admin/Roomtypes");
        }

        public async Task DeleteRoomtype(int id)
        {
            var result = await _http.DeleteAsync($"api/Roomtype/{id}");
            _navigationManger.NavigateTo("admin/Roomtypes");
        }


        public async Task<Roomtype?> GetRoomtypeById(int id)
        {
            var result = await _http.GetAsync($"api/Roomtype/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Roomtype>();
            }
            return null;
        }

        public async Task GetRoomtypes()
        {
            var result = await _http.GetFromJsonAsync<List<Roomtype>>("api/Roomtype");
            if (result is not null)
                Roomtypes = result;
        }

        public async Task UpdateRoomtype(int id, Roomtype Roomtype)
        {
            await _http.PutAsJsonAsync($"api/Roomtype/{id}", Roomtype);
            _navigationManger.NavigateTo("admin/Roomtypes");
        }
    }
}