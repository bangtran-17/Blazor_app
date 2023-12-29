using System.Net;
using Hotel.Server.Data;

using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly MyDbContext _context;

        public RoomService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Room> CreateRoom(Room? Room)
        {
            Room.RAvailable = "yes";
             
            _context.Add(Room);
            await _context.SaveChangesAsync();
            return Room;
        }

        public async Task<bool> DeleteRoom(int RoomId)
        {
            var dbRoom = await _context.Rooms.FindAsync(RoomId);
            if (dbRoom == null)
            {
                return false;
            }

            _context.Remove(dbRoom);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Room?> GetRoomById(int RoomId)
        {
            var dbRoom = await _context.Rooms.FindAsync(RoomId);
            return dbRoom;
        }
        public async Task<List<Room>> GetRoomByFName(string fname)
        {
            //var dbRoom = await _context.Rooms.FirstOrDefaultAsync(e => e.EFirstName == fname);
            var dbRoom = await _context.Rooms
                    .Where(e =>
                        EF.Functions.Like(e.RAvailable, $"%{fname}%") ||
                        EF.Functions.Like(e.RNumber, $"%{fname}%") ||
                        EF.Functions.Like(e.Status, $"%{fname}%") ||
                        EF.Functions.Like(e.Rt.RtName, $"%{fname}%")||
                        EF.Functions.Like(e.RtId.ToString(), $"%{fname}%")
                        )
                    .ToListAsync();
            return dbRoom;
        }
        public async Task<Room?> GetRoomByRName(string Rname)
        {
            // Sử dụng LINQ để truy vấn Room theo Rname
            var room = await _context.Rooms
                .Where(r => r.RNumber == Rname)
                .FirstOrDefaultAsync();

            return room;
        }
        public async Task<List<Room>> GetRoomByRoomTypeId(int RtId)
        {
            // Sử dụng LINQ để truy vấn Room theo Rname
            var room = await _context.Rooms
                .Where(r => r.RtId == RtId)
                .ToListAsync();

            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room?> UpdateRoom(int RoomId, Room Room)
        {
            var dbRoom = await _context.Rooms.FindAsync(RoomId);
            if (dbRoom != null)
            {
                dbRoom.RId = Room.RId;
                dbRoom.RNumber = Room.RNumber;
                dbRoom.RtId = Room.RtId;
                dbRoom.RAvailable = Room.RAvailable;
                dbRoom.Status = Room.Status;
           


                await _context.SaveChangesAsync();
            }

            return dbRoom;
        }
    }
}
