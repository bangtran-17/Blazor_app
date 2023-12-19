using Hotel.Shared.Models;

namespace Hotel.Server.Services.VNPAY
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(Payment model, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
