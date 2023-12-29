
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
        public async Task<List<Booking>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }
        public async Task<Booking> CreateBooking(Booking Booking)
        {
            Console.WriteLine("server: ", Booking.BDate);
            _context.Add(Booking);
            await _context.SaveChangesAsync();
            
            return Booking;
        }
        public async Task<Booking?> GetBookingById(int BookingId)
        {
            var dbBooking = await _context.Bookings.FindAsync(BookingId);
            return dbBooking;
        }
        public async Task<List<Booking>> SearchBookings(string searchText)
        {
            var dbBookings = await _context.Bookings
                .Where(d =>
                    EF.Functions.Like(d.BId.ToString(), $"%{searchText}%") ||
                    EF.Functions.Like(d.BDate.ToString(), $"%{searchText}%") ||
                    EF.Functions.Like(d.BAmount.ToString(), $"%{searchText}%") ||
                    EF.Functions.Like(d.Rid.ToString(), $"%{searchText}%") ||
                    EF.Functions.Like(d.BCost.ToString(), $"%{searchText}%"))
                .ToListAsync();

            return dbBookings;
        }
        public async Task<Booking?> UpdateBooking(int BId, Booking booking)
        {
            Console.WriteLine("server: ",booking.BDate);
            var dbEmployee = await _context.Bookings.FindAsync(BId);
            if (dbEmployee != null)
            {
                dbEmployee.BId = booking.BId;
                dbEmployee.BDate = booking.BDate;
                dbEmployee.BStayDuration = booking.BStayDuration;
                dbEmployee.BCheckingDate = booking.BCheckingDate;
                dbEmployee.BCheckoutDate = booking.BCheckoutDate;
                dbEmployee.BAmount = booking.BAmount;
                dbEmployee.HId = booking.HId;
                dbEmployee.EId = booking.EId;
                dbEmployee.GId = booking.GId;
                dbEmployee.DId = booking.DId;
                dbEmployee.BStatus = booking.BStatus;
                dbEmployee.Rid = booking.Rid;
                dbEmployee.BCost = booking.BCost;
                dbEmployee.StripeSessionId = booking.StripeSessionId;


                await _context.SaveChangesAsync();
            }

            return dbEmployee;
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
    }
}
