using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Shared.Models;
using Hotel.Server.Services.BookingService;

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

        [HttpGet("{id}")]
        public async Task<Booking?> GetBookingById(int id)
        {
            return await _BookingService.GetBookingById(id);
        }

        
    }
}
