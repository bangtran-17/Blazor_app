using Hotel.Shared.Models;

namespace Hotel.Server.Services.RoomtypeService
{
    public interface IRoomTypeService
    {
        Task<List<Roomtype>> GetRoomtypes();
        Task<Roomtype?> GetRoomtypeById(int RoomtypeId);
        Task<Roomtype> CreateRoomtype(Roomtype Roomtype);
        Task<Roomtype?> UpdateRoomtype(int RoomtypeId, Roomtype Roomtype);
        Task<bool> DeleteRoomtype(int RoomtypeId);
    }
}
