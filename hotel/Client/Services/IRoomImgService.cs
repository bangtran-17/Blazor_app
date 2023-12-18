using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
    public interface IRoomImgService
    {
        List<RoomImg?> RoomImgs { get; set; }
        //List<Payment> Payment { get; set; }
        Task GetRoomImgs();
        Task<RoomImg?> GetRoomImgById(int? RtId);






    }
}
