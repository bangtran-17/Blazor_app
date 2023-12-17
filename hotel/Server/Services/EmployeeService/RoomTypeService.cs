
using System.Net;
using Hotel.Server.Data;

using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Services.RoomtypeService
{
    public class RoomtypeService : IRoomTypeService
    {
        private readonly MyDbContext _context;

        public RoomtypeService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Roomtype> CreateRoomtype(Roomtype Roomtype)
        {
            _context.Add(Roomtype);
            await _context.SaveChangesAsync();
            return Roomtype;
        }

        public async Task<bool> DeleteRoomtype(int RoomtypeId)
        {
            var dbRoomtype = await _context.Roomtypes.FindAsync(RoomtypeId);
            if (dbRoomtype == null)
            {
                return false;
            }

            _context.Remove(dbRoomtype);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Roomtype?> GetRoomtypeById(int RoomtypeId)
        {
            var dbRoomtype = await _context.Roomtypes.FindAsync(RoomtypeId);
            return dbRoomtype;
        }
      
        //public async Task<List<Roomtype>> SearchRoomtypes(string searchText)
        //{
        //    var result = await _context.Roomtypes
        //        .Where(e =>
        //            EF.Functions.Like(e.EFirstName, $"%{searchText}%") ||
        //            EF.Functions.Like(e.ELastName, $"%{searchText}%") ||
        //            EF.Functions.Like(e.EDesignation, $"%{searchText}%") ||
        //            EF.Functions.Like(e.EContactNumber, $"%{searchText}%") ||
        //            EF.Functions.Like(e.EEmail, $"%{searchText}%") ||
        //            EF.Functions.Like(e.EAddress, $"%{searchText}%"))
        //        .ToListAsync();

        //    return result;
        //}


        public async Task<List<Roomtype>> GetRoomtypes()
        {
            return await _context.Roomtypes.ToListAsync();
        }

        public async Task<Roomtype?> UpdateRoomtype(int RoomtypeId, Roomtype Roomtype)
        {
            var dbRoomtype = await _context.Roomtypes.FindAsync(RoomtypeId);
            if (dbRoomtype != null)
            {
                dbRoomtype.RtId = Roomtype.RtId;
                dbRoomtype.RtCost = Roomtype.RtCost;    
                dbRoomtype.RtDes = Roomtype.RtDes;
                dbRoomtype.RArea = Roomtype.RArea;
                dbRoomtype.RtName = Roomtype.RtName;
                dbRoomtype.Status = Roomtype.Status;
                dbRoomtype.RtSmokeFriendly = Roomtype.RtSmokeFriendly;


                await _context.SaveChangesAsync();
            }

            return dbRoomtype;
        }
    }
}
