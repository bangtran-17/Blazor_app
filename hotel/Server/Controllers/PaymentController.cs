using Hotel.Server.Services.PayMent;
using Hotel.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace Hotel.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaymentController : Controller
    {

        private readonly IPaymentService _repository;

        public PaymentController(IPaymentService repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<List<Payment?>> Get()
        {
            return await _repository.GetPayments();
        }
        [HttpGet("{id}")]
        public async Task<Payment?> GetById(int id)
        {
            return await _repository.GetCostById(id);
        }
        [HttpPut("{id}")]
        public async Task<Payment?> Update(int id, Payment payment)
        {
            return await _repository.UpdatePayment(id, payment);
        }
        [HttpPost("{Bid}")]
        public async Task<Payment?> Create(Payment payment,int Bid)
        {
            return await _repository.CreatePayment(payment,Bid);
        }
        [HttpPost]
        public async Task<IActionResult> PaymentSuccessful([FromBody] Booking details)
        {
            //Validate payment
            var service = new SessionService();
            var sessionDetails = service.Get(details.StripeSessionId);

            if (sessionDetails.PaymentStatus == "paid")
            {

                var result = await _repository.PaymentSuccessful(details.BId);
                if (result == null)
                {
                    return BadRequest(new ErrorModel()
                    {
                        ErrorMessage = "Payment not successful"
                    });
                }
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel()
                {
                    ErrorMessage = "Payment not successful"
                });
            }
        }
    }
}
