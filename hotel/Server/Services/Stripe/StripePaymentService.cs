using Hotel.Shared.Models;
using Stripe;
using Stripe.Checkout;
using static System.Net.WebRequestMethods;


namespace Hotel.Server.Services.Stripe
{
    public class StripePaymentService : IStripePaymentService
    {
        public StripePaymentService()
        {
            StripeConfiguration.ApiKey = "sk_test_51OPojxFvPhzJoAddKZW1svdvfx0vkIEc8cZbbvIs3r0HAypEYufE3VauC8zIVr4bmkXiCY7aXFh1KtTKRBDAB4tc00DjnMKnLJ";
        }

        public Session CreateCheckoutSession(StripePaymentDTO payment)
        {
        

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                    {
                        "card"
                    },
                LineItems = new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                UnitAmount=payment.Cost,
                                Currency="USD",
                                ProductData= new SessionLineItemPriceDataProductDataOptions
                                {
                                    Name = payment.ProductName
                                }
                            },
                            Quantity=1
                        }
                    },
                Mode = "payment",
                SuccessUrl = "https://localhost:7192/success-payment",
                CancelUrl = "https://localhost:7192/booking"
            };
            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }
    }
}
