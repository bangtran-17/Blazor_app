using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Shared.Models;
using Hotel.Server.Services.BookingService;
using NuGet.Protocol.Core.Types;
using Stripe.Checkout;

namespace Hotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;

        public BookingController(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        [HttpGet]
        public async Task<List<Booking>> GetBookings()
        {
            return await _BookingService.GetBookings();
           
        }
        [HttpGet("search/{searchText}")]
        public async Task<List<Booking>> SearchBookings(string searchText)
        {
            return await _BookingService.SearchBookings(searchText);
        }
        [HttpPost]
        public async Task<Booking?> CreateBooking(Booking booking)
        {
            return await _BookingService.CreateBooking(booking);
        }
        [HttpPut("{id}")]
        public async Task<Booking?> UpdateBooking(int id, Booking Booking)
        {
            return await _BookingService.UpdateBooking(id, Booking);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteBooking(int id)
        {
            return await _BookingService.DeleteBooking(id);
        }

        [HttpGet("{id}")]
        public async Task<Booking?> GetBookingById(int id)
        {
            return await _BookingService.GetBookingById(id);
        }


        //[HttpGet("payment/{id}")]
        //public  int? GetCostById(int id)
        //{
        //    return _BookingService.GetCostById(id);
        //}


    }
}
