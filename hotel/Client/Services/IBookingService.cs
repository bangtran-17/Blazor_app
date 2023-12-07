using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
    public interface IBookingService
    {
        List<Booking> Bookings { get; set; }
        Task GetBookings();
        Task<Booking?> GetBookingById(int id);
        Task<Booking?> GetBookingByFName(string fname);
        Task CreateBooking(Booking Booking);
        Task UpdateBooking(int id, Booking Booking);
        Task DeleteBooking(int id);

    }
}
