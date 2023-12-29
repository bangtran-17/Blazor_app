
using Hotel.Shared.Models;
namespace Hotel.Server.Services.BookingService
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookings();
        Task<Booking?> GetBookingById(int BookingId);
        Task<List<Booking>> SearchBookings(string searchText);
        Task<Booking> CreateBooking(Booking Booking);
        Task<Booking?> UpdateBooking(int BId, Booking booking);
        Task<bool> DeleteBooking(int BId);

       
        Task<List<Booking>> SearchBookingsByGid(int gid);
    }
}
