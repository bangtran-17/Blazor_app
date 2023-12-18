
using Hotel.Client;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;


namespace Hotel.Client.Services
{
	public class GuestService : IGuestService
	{
		private readonly HttpClient _http;
		private readonly NavigationManager _navigationManger;

		public GuestService(HttpClient http, NavigationManager navigationManger)
		{
			_http = http;
			_navigationManger = navigationManger;
		}

		public List<Guest> Guests { get; set; } = new List<Guest>();

		public async Task CreateGuest(Guest? Guest)
		{
			await _http.PostAsJsonAsync("api/Guest", Guest);
			_navigationManger.NavigateTo("admin/Guests");
		}

		public async Task DeleteGuest(int id)
		{
			var result = await _http.DeleteAsync($"api/Guest/{id}");
			_navigationManger.NavigateTo("admin/Guests");
		}

		public async Task<Guest?> SearchGuests(string searchText)
		{
			var result = await _http.GetAsync($"api/Guest/name/{searchText}");
			if (result.StatusCode == HttpStatusCode.OK)
			{
				return await result.Content.ReadFromJsonAsync<Guest>();
			}
			return null;
		}

		public async Task<Guest?> GetGuestById(int id)
		{
			var result = await _http.GetAsync($"api/Guest/{id}");
			if (result.StatusCode == HttpStatusCode.OK)
			{
				return await result.Content.ReadFromJsonAsync<Guest>();
			}
			return null;
		}

		public async Task GetGuests()
		{
			var result = await _http.GetFromJsonAsync<List<Guest>>("api/Guest");
			if (result is not null)
				Guests = result;
		}

		public async Task UpdateGuest(int id, Guest Guest)
		{
			await _http.PutAsJsonAsync($"api/Guest/{id}", Guest);
			_navigationManger.NavigateTo("admin/Guests");
		}
	}
}