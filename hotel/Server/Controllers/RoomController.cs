using Microsoft.AspNetCore.Mvc;
using Hotel.Shared.Models;
using Hotel.Server.Services.Rooms;

namespace Hotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _RoomService;

        public RoomController(IRoomService RoomService)
        {
            _RoomService = RoomService;
        }

        [HttpGet]
        public async Task<List<Room>> GetRooms()
        {
            return await _RoomService.GetRooms();
        }

        [HttpGet("{id}")]
        public async Task<Room?> GetRoomById(int id)
        {
            return await _RoomService.GetRoomById(id);
        }

        [HttpGet("search/{searchText}")]
        public async Task<List<Room>> GetRoomByFName(string searchText)
        {
            return await _RoomService.GetRoomByFName(searchText);
        }

        [HttpPost]
        public async Task<Room?> CreateRoom(Room? Room)
        {
            return await _RoomService.CreateRoom(Room);
        }

        [HttpPut("{id}")]
        public async Task<Room?> UpdateRoom(int id, Room Room)
        {
            return await _RoomService.UpdateRoom(id, Room);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteRoom(int id)
        {
            return await _RoomService.DeleteRoom(id);
        }
    }
}
