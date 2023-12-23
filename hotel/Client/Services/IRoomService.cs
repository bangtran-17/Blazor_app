﻿
using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
    public interface IRoomService
    {
        List<Room> Rooms { get; set; }
        Task GetRooms();
        Task<Room?> GetRoomById(int id);
        Task<Room?> GetRoomByFName(string fname);
        Task CreateRoom(Room? Room);
        Task UpdateRoom(int id, Room Room);
        Task DeleteRoom(int id);

    }
}