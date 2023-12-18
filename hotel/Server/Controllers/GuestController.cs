using Hotel.Server.Services;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Hotel.Shared.Models;
using Hotel.Server.Services.GuestService;

namespace Hotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _GuestService;

        public GuestController(IGuestService GuestService)
        {
            _GuestService = GuestService;
        }

        [HttpGet]
        public async Task<List<Guest>> GetGuests()
        {
            return await _GuestService.GetGuests();
        }

        [HttpGet("{id}")]
        public async Task<Guest?> GetGuestById(int id)
        {
            return await _GuestService.GetGuestById(id);
        }

        [HttpGet("search/{searchText}")]
        public async Task<List<Guest>> SearchGuests(string searchText)
        {
            return await _GuestService.SearchGuests(searchText);
        }

        [HttpPost]
        public async Task<Guest?> CreateGuest(Guest? Guest)
        {
            return await _GuestService.CreateGuest(Guest);
        }

        [HttpPut("{id}")]
        public async Task<Guest?> UpdateGuest(int id, Guest Guest)
        {
            return await _GuestService.UpdateGuest(id, Guest);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteGuest(int id)
        {
            return await _GuestService.DeleteGuest(id);
        }
    }
}