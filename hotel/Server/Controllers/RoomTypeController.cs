using Hotel.Server.Services.RoomtypeService;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService; 
        }

        [HttpGet]
        public async Task<List<Roomtype>> GetRoomtypes()
        {
            return await _roomTypeService.GetRoomtypes();
        }

        [HttpGet("{id}")]
        public async Task<Roomtype?> GetRoomtypeById(int id)
        {
            return await _roomTypeService.GetRoomtypeById(id);
        }

        [HttpPost]
        public async Task<Roomtype?> CreateRoomtype(Roomtype Roomtype)
        {
            return await _roomTypeService.CreateRoomtype(Roomtype);
        }

        [HttpPut("{id}")]
        public async Task<Roomtype?> UpdateRoomtype(int id, Roomtype Roomtype)
        {
            return await _roomTypeService.UpdateRoomtype(id, Roomtype);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteRoomtype(int id)
        {
            return await _roomTypeService.DeleteRoomtype(id);
        }

    }
}
