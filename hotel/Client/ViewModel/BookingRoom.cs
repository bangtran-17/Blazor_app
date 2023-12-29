using Hotel.Shared.Models;

namespace Hotel.Client.ViewModel
{
    public class BookingRoom
    {
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public List<Room> Rooms { get; set; } = new List<Room> { };
    }
}
