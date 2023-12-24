using Hotel.Server.Services.VNPAY;
using Hotel.Server.SignalR;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol;


namespace Hotel.Server.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class VNPAYController : ControllerBase
    {
        private readonly IVnPayService _vnPayService;
        private IHubContext<SignalrHub> _hubContext;


        public VNPAYController(IVnPayService vnPayService, IHubContext<SignalrHub> hubContext)
        {
            _hubContext = hubContext;
            _vnPayService = vnPayService;
        }


        [HttpPost("CreatePaymentUrl")]
        public IActionResult CreatePaymentUrl(Payment model)
        {
            var url = _vnPayService.CreatePaymentUrl(model, HttpContext);

            return Ok(url);
        }

        [HttpGet("PaymentCallback")]
        public async Task<IActionResult> PaymentCallback()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);

            //var hubConnection = new HubConnectionBuilder()
            //    .WithUrl("https://localhost:7192/paymentHub")
            //    .Build();

            //await hubConnection.StartAsync();

            //await hubConnection.SendAsync("SendPaymentResponse", response);

            await _hubContext.Clients.All.SendAsync("BroadcastMessage", response);

            //return Ok(response);
            return Redirect("/");
            //return true;
        }
    }
}
