
using System.Net;
using Hotel.Server.Data;

using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Services.GuestService
{
    public class GuestService : IGuestService
    {
        private readonly MyDbContext _context;

        public GuestService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Guest> CreateGuest(Guest? Guest)
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
        public async Task<List<Guest>> GetGuestByFName(string fname)
        {
            //var dbGuest = await _context.Guests.FirstOrDefaultAsync(e => e.EFirstName == fname);
            var dbGuest = await _context.Guests
                    .Where(e =>
                        EF.Functions.Like(e.GFirstName, $"%{fname}%") ||
                        EF.Functions.Like(e.GLastName, $"%{fname}%") ||
                        EF.Functions.Like(e.GEmail, $"%{fname}%") ||
                        EF.Functions.Like(e.GCccd, $"%{fname}%") ||
                        EF.Functions.Like(e.GAccount, $"%{fname}%") ||
                        EF.Functions.Like(e.GSdt, $"%{fname}%"))
                    .ToListAsync();
            return dbGuest;
        }
        //public async Task<List<Guest>> SearchGuests(string searchText)
        //{
        //    var result = await _context.Guests
        //        .Where(e =>
        //            EF.Functions.Like(e.EFirstName, $"%{searchText}%") ||
        //            EF.Functions.Like(e.ELastName, $"%{searchText}%") ||
        //            EF.Functions.Like(e.EDesignation, $"%{searchText}%") ||
        //            EF.Functions.Like(e.EContactNumber, $"%{searchText}%") ||
        //            EF.Functions.Like(e.EEmail, $"%{searchText}%") ||
        //            EF.Functions.Like(e.EAddress, $"%{searchText}%"))
        //        .ToListAsync();

        //    return result;
        //}


        public async Task<List<Guest>> GetGuests()
        {
            return await _context.Guests.ToListAsync();
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
                

                await _context.SaveChangesAsync();
            }

            return dbGuest;
        }
    }
}
