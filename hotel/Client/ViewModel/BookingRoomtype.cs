using System;
using Hotel.Shared.Models;
namespace Hotel.Client.ViewModel
{
    public class BookingRoomtype
    {
        public Booking booking { get; set; } = new Booking();
        public Roomtype roomtype { get; set; }=new Roomtype();
    }
}
