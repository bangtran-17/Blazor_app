using Hotel.Shared.Models;
namespace Hotel.Server.Services.RoomImg
{
    public interface IRoomImgService
    {
        Task<List<Hotel.Shared.Models.RoomImg>> GetRoomImgs();
        Task<Hotel.Shared.Models.RoomImg?> GetRoomImgById(int? RoomImgId);

   

    }
}
