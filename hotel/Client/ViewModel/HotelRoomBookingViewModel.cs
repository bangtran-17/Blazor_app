using Hotel.Shared.Models;

namespace Hotel.Client.ViewModel
{
    public class HotelRoomBookingViewModel
    {
        public Booking orderDetails { get; set; } = new Booking();
        public Guest guest { get; set; }= new Guest();
        public HomeVM homeVM { get; set; } = new HomeVM();
    }
}
