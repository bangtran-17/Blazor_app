using Hotel.Client;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Hotel.Client.Services
{
    public class RoomImgService : IRoomImgService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public RoomImgService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }

        public List<RoomImg?> RoomImgs { get; set; } = new List<RoomImg?>();

        //public async Task<RoomImg?> GetRoomImgById(int? RtId)
        //{
        //    var options = new JsonSerializerOptions()
        //    {
        //        ReferenceHandler = ReferenceHandler.Preserve,
        //        PropertyNameCaseInsensitive = true
        //    };
        //    var result = await _http.GetAsync($"api/RoomImg/{RtId}");
        //    if (result.StatusCode == HttpStatusCode.OK)
        //    {
        //        return await result.Content.ReadFromJsonAsync<RoomImg>(options);
        //    }
        //    return null;
        //}

        public async Task<List<RoomImg?>> GetRoomImgs()
        {
            var options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };
            var result = await _http.GetFromJsonAsync<List<RoomImg>>("api/RoomImg",options);
            if (result is not null)
                RoomImgs = result;
            return RoomImgs;
        }
       
    


    }
}