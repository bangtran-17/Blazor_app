﻿
using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
    public interface IRoomService
    {
        List<Room> Rooms { get; set; }
        Task<List<Room>> GetRooms();
        Task<Room?> GetRoomById(int id);
        Task<List<Room>> GetRoomByFName(string fname);
        Task CreateRoom(Room? Room);
        Task UpdateRoom(int id, Room Room);
        Task DeleteRoom(int id);

    }
}