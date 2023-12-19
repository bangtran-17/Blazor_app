using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
    public interface IPaymentService
    {
        List<Payment> Payments { get; set; }
        public Task<Booking> PaymentSuccessful(Booking details);
        public  Task GetPayments();
        public Task CreatePayment(Payment Payment);
        public Task UpdatePayment(int id, Payment payment);
        public Task<Payment?> GetCostById(int id);
        
    }
}
