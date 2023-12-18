
using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
	public interface IGuestService
	{
		List<Guest> Guests { get; set; }
		Task GetGuests();
		Task<Guest?> GetGuestById(int id);
        Task<List<Guest?>> SearchGuests(string searchText);
        Task CreateGuest(Guest Guest);
		Task UpdateGuest(int id, Guest Guest);
		Task DeleteGuest(int id);

	}
}