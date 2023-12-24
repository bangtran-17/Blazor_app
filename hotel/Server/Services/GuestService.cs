using Hotel.Server.Data;
using Hotel.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Services
{
    public class GuestService : IGuestService
    {
        private readonly MyDbContext _context;
        public GuestService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Guest> CreateGuest(Guest Guest)
        {
            _context.Add(Guest);
            await _context.SaveChangesAsync();
            return Guest;
        }

        public async Task<bool> DeleteGuest(int GuestId)
        {
            var dbGuest = await _context.Guests.FindAsync(GuestId);
            if (dbGuest == null)
            {
                return false;
            }

            _context.Remove(dbGuest);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Guest?> GetGuestById(int GuestId)
        {
            var dbGuest = await _context.Guests.FindAsync(GuestId);
            return dbGuest;
        }

        public async Task<List<Guest>> GetGuests()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<List<Guest>> SearchGuests(string searchText)
        {
            var dbGuest = await _context.Guests
                .Where(e =>
                    EF.Functions.Like(e.GFirstName, $"%{searchText}%") ||
                    EF.Functions.Like(e.GLastName, $"%{searchText}%") ||
                    EF.Functions.Like(e.GSdt, $"%{searchText}%") ||
                    EF.Functions.Like(e.GEmail, $"%{searchText}%") ||
                    EF.Functions.Like(e.GCccd, $"%{searchText}%"))
                .ToListAsync();

            return dbGuest;
        }

        public async Task<Guest?> UpdateGuest(int GuestId, Guest Guest)
        {
            var dbGuest = await _context.Guests.FindAsync(GuestId);
            if (dbGuest != null)
            {
                dbGuest.GId = Guest.GId;
                dbGuest.GFirstName = Guest.GFirstName;
                dbGuest.GLastName = Guest.GLastName;
                dbGuest.GSdt = Guest.GSdt;
                dbGuest.GEmail = Guest.GEmail;
                dbGuest.GCccd = Guest.GCccd;
                dbGuest.GAccount = Guest.GAccount;
                dbGuest.Status = Guest.Status;

                await _context.SaveChangesAsync();
            }

            return dbGuest;
        }
    }
}
