﻿using Hotel.Shared.Models;

namespace Hotel.Client.Services
{
    public interface IBookingService
    {
        List<Booking> Bookings { get; set; }
        //List<Payment> Payment { get; set; }
        Task GetBookings();
        Task<Booking?> GetBookingById(int id);

        //Task<int?> GetCostById(int id);

        Task CreateBooking(Booking Booking);
        Task UpdateBooking(int id, Booking Booking);
        Task DeleteBooking(int id);
        //Task<Booking> PaymentSuccessful(Booking details);

        //Task GetPayments();
        //Task CreatePayment(Payment Paymment,int Bid);

        //Task UpdatePayment(int id, Payment payment);






    }
}
