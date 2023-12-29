using Hotel.Shared.Models;
namespace Hotel.Server.Services.Rooms
{
    public interface IRoomService
    {
        Task<List<Hotel.Shared.Models.Room>> GetRooms();
        Task<Hotel.Shared.Models.Room?> GetRoomById(int RoomId);
        Task<List<Hotel.Shared.Models.Room>> GetRoomByFName(string searchText);
        Task<Room?> GetRoomByRName(string Rname);
        Task<List<Room>> GetRoomByRoomTypeId(int RtId);
        Task<Hotel.Shared.Models.Room> CreateRoom(Hotel.Shared.Models.Room? Room);
        Task<Hotel.Shared.Models.Room?> UpdateRoom(int RoomId, Hotel.Shared.Models.Room Room);
        Task<bool> DeleteRoom(int RoomId);
    }
}
