using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Shared.Models;
using Hotel.Server.Services.RoomImg;
using NuGet.Protocol.Core.Types;
using Stripe.Checkout;

namespace Hotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomImgController : ControllerBase
    {
        private readonly IRoomImgService _RoomImgService;

        public RoomImgController(IRoomImgService RoomImgService)
        {
            _RoomImgService = RoomImgService;
        }

        [HttpGet]
        public async Task<List<RoomImg>> GetRoomImgs()
        {
            return await _RoomImgService.GetRoomImgs();
        }

        [HttpGet("{id}")]
        public async Task<RoomImg?> GetRoomImgById(int? id)
        {
            return await _RoomImgService.GetRoomImgById(id);
        }


        //[HttpGet("payment/{id}")]
        //public  int? GetCostById(int id)
        //{
        //    return _RoomImgService.GetCostById(id);
        //}


    }
}
