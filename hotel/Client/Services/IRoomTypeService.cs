using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
    public interface IRoomtypeService
    {
        List<Roomtype> Roomtypes { get; set; }
        Task GetRoomtypes();
        Task<Roomtype?> GetRoomtypeById(int id);
        
        Task CreateRoomtype(Roomtype Roomtype);
        Task UpdateRoomtype(int id, Roomtype Roomtype);
        Task DeleteRoomtype(int id);
    }
}
