using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
    public interface IStripePaymentService
    {
        public Task<string> CheckOutCompleted(StripePaymentDTO? model);

    }
}
