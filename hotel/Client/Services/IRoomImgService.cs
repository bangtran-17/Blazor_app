using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
    public interface IRoomImgService
    {
        List<RoomImg?> RoomImgs { get; set; }
        //List<Payment> Payment { get; set; }
        Task<List<RoomImg>> GetRoomImgs();
        Task<RoomImg?> GetRoomImgById(int? RtId);






    }
}
