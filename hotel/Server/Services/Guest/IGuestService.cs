
using Hotel.Shared.Models;
namespace Hotel.Server.Services.GuestService
{
    public interface IGuestService
    {
        Task<List<Guest>> GetGuests();
        Task<Guest?> GetGuestById(int GuestId);
        Task<List<Guest>> GetGuestByFName(string searchText);
        Task<Guest> CreateGuest(Guest Guest);
        Task<Guest?> UpdateGuest(int GuestId, Guest Guest);
        Task<bool> DeleteGuest(int GuestId);
    }
}
