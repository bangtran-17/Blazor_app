using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Stripe.Checkout;
using Stripe;
using System.Collections.Generic;
using Hotel.Shared.Models;
using Hotel.Server.Services.PayMent;
using Hotel.Server.Services.Stripe;

namespace Hotel.Server.Controllers
{
    [Route("api/[controller]" )]
    [ApiController]
    public class StripePaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IStripePaymentService _stripePaymentService;

        public StripePaymentController(IConfiguration configuration,IStripePaymentService stripePaymentService)
        {
            _configuration = configuration;
            _stripePaymentService = stripePaymentService;
        }

        [HttpPost("checkout")]
       public ActionResult CreateCheckoutSession(StripePaymentDTO stripePayment)
        {
            var result = _stripePaymentService.CreateCheckoutSession(stripePayment);
            return Ok(result.Url);
        }
    }
}
