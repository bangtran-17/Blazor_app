using Hotel.Shared.Models;
using System.Net.Http;

namespace Hotel.Client.Services
{
    public interface IVnPayService
    {
        Task<string> CreatePaymentUrl(Payment model);
        //PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
