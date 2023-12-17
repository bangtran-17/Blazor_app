
using Hotel.Shared.Models;

namespace Hotel.Server.Services.PayMent
{
    public interface IPaymentService
    {
        Task<Booking?> PaymentSuccessful(int id);
        Task<List<Payment?>> GetPayments();
        Task<Payment?> CreatePayment(Payment Payment, int Bid);
        Task<Payment?> UpdatePayment(int id, Payment payment);
        Task<Payment?> GetCostById(int id);
    }
}
