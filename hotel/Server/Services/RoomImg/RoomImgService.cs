
using System.Net;
using Hotel.Server.Data;

using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Services.RoomImg
{
    public class RoomImgService : IRoomImgService
    {
        private readonly MyDbContext _context;

        public RoomImgService(MyDbContext context)
        {
            _context = context;
        }

        
        public async Task<Hotel.Shared.Models.RoomImg?> GetRoomImgById(int? RoomImgId)
        {

            var dbRoomImg = await _context.RoomImgs.SingleAsync(p => p.Room.RtId == RoomImgId);
            return dbRoomImg;
        }

        public async Task<List<Hotel.Shared.Models.RoomImg>> GetRoomImgs()
        {
            return await _context.RoomImgs.ToListAsync();
        }


    }
}
