using Hotel.Server.Services.VNPAY;
using Hotel.Server.SignalR;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NuGet.Packaging.Signing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.AccessControl;

namespace Hotel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VNPAYController : ControllerBase
    {
        private readonly IVnPayService _vnPayService;
        private IHubContext<SignalrHub, IHubClient> _signalrHub;

        public VNPAYController(IVnPayService vnPayService, IHubContext<SignalrHub, IHubClient> signalrHub)
        {
            _signalrHub = signalrHub;
            _vnPayService = vnPayService;
        }
        [HttpPost("CreatePaymentUrl")]
        public IActionResult CreatePaymentUrl(Payment model)
        {
            var url = _vnPayService.CreatePaymentUrl(model, HttpContext);

            return Ok(url);
        }

        [HttpGet("PaymentCallback")]
        public IActionResult PaymentCallback()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            // Send the response to connected clients
            _signalrHub.Clients.All.BroadcastMessage(response);
            //_signalrHub.Clients.All.SendAsync("ReceivePaymentCallback", response);


            return Ok(response);
        }
    }
}
