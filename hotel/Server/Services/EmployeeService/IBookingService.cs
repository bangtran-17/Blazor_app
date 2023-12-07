
using Hotel.Shared.Models;
namespace Hotel.Server.Services.BookingService
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookings();
        Task<Booking?> GetBookingById(int BookingId);

        Task<Booking> CreateBooking(Booking Booking);


    }
}
