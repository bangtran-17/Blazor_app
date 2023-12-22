﻿
using Hotel.Client;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;


namespace Hotel.Client.Services
{
    public class RoomService : IRoomService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public RoomService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }

        public List<Room> Rooms { get; set; } = new List<Room>();

        public async Task CreateRoom(Room? Room)
        {
            await _http.PostAsJsonAsync("api/Room", Room);
            _navigationManger.NavigateTo("admin/Rooms");
        }

        public async Task DeleteRoom(int id)
        {
            var result = await _http.DeleteAsync($"api/Room/{id}");
            _navigationManger.NavigateTo("admin/Rooms");
        }

        public async Task<Room?> GetRoomByFName(string fname)
        {
            var result = await _http.GetAsync($"api/Room/name/{fname}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Room>();
            }
            return null;
        }

        public async Task<Room?> GetRoomById(int id)
        {
            var result = await _http.GetAsync($"api/Room/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Room>();
            }
            return null;
        }

        public async Task GetRooms()
        {
            var result = await _http.GetFromJsonAsync<List<Room>>("api/Room");
            if (result is not null)
                Rooms = result;
        }

        public async Task UpdateRoom(int id, Room Room)
        {
            await _http.PutAsJsonAsync($"api/Room/{id}", Room);
            _navigationManger.NavigateTo("admin/Rooms");
        }
    }
}