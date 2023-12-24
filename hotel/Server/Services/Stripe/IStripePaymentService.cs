using Hotel.Shared.Models;
using Stripe.Checkout;

namespace Hotel.Server.Services.Stripe
{
    public interface IStripePaymentService
    {
        Session CreateCheckoutSession(StripePaymentDTO paymentDTO);
    }
}
