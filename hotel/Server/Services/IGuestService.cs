﻿using Hotel.Shared.Models;

namespace Hotel.Server.Services
{
    public interface IGuestService
    {
        Task<List<Guest>> GetGuests();
        Task<Guest?> GetGuestById(int GuestId);
        Task<List<Guest>> SearchGuests(string searchText);
        Task<Guest> CreateGuest(Guest Guest);
        Task<Guest?> UpdateGuest(int GuestId, Guest Guest);
        Task<bool> DeleteGuest(int GuestId);
        Task<Guest?> GetGuestByName(string name);
        Task<Guest?> GetGuestByEmail(string email);
    }
}