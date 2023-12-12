
using System.Net;
using Hotel.Server.Data;

using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly MyDbContext _context;

        public BookingService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> CreateBooking(Booking Booking)
        {
            _context.Add(Booking);
            await _context.SaveChangesAsync();
            return Booking;
        }

        public async Task<bool> DeleteBooking(int BookingId)
        {
            var dbBooking = await _context.Bookings.FindAsync(BookingId);
            if (dbBooking == null)
            {
                return false;
            }

            _context.Remove(dbBooking);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Booking?> GetBookingById(int BookingId)
        {
            var dbBooking = await _context.Bookings.FindAsync(BookingId);
            return dbBooking;
        }
        public async Task<Booking?> UpdateBooking(int BId, Booking booking)
        {
            var dbEmployee = await _context.Bookings.FindAsync(BId);
            if (dbEmployee != null)
            {
                dbEmployee.BId = booking.BId;
                dbEmployee.BCheckingDate = booking.BCheckingDate;
                dbEmployee.BCheckoutDate = booking.BCheckoutDate;
                dbEmployee.BAmount = booking.BAmount;
                dbEmployee.BStatus = booking.BStatus;


                await _context.SaveChangesAsync();
            }

            return dbEmployee;
        }

        //public async Task<List<Booking>> SearchBookings(string searchText)
        //{
        //    var result = await _context.Bookings
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


        public async Task<List<Booking>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

       
    }
}
