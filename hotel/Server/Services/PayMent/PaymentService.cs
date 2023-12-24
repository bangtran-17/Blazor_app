using Hotel.Server.Data;
using Hotel.Shared.CommonFiles;
using Hotel.Shared.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.AccessControl;

namespace Hotel.Server.Services.PayMent
{
    public class PaymentService : IPaymentService
    {
        private readonly MyDbContext _context;
        //private readonly IMapper _mapper;

        public PaymentService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Payment?> CreatePayment(Payment Payment)
        { 
            //var bookingID = _context.Bookings.Where(p => p.BId == Bid).FirstOrDefault().BId;
      
            _context.Add(Payment);
            await _context.SaveChangesAsync();
            return Payment;
           
        }

        public async Task<Payment?> GetCostById(int id)
        {
            var dbPayments = await _context.Payments.SingleAsync(p=>p.BId == id);
            return dbPayments;
        }


        public async Task<List<Payment?>> GetPayments()
    {
        return await _context.Payments.ToListAsync();
    }
    public async Task<Booking?> PaymentSuccessful(int id)
    {
        var data = await _context.Bookings.FindAsync(id);
        if (data == null)
        {
            return null;
        }
        if (data.BStatus=="notpaid")
        {
            data.BStatus = "paid";
            data.BStatus = SD.Status_Booked;

                var paymentSuccess = _context.Bookings.Update(data);
                await _context.SaveChangesAsync();
                //return _mapper.Map<Booking>(paymentSuccess.Entity);
            }
            return new Booking();
        }

      

        public async Task<Payment?> UpdatePayment(int id, Payment payment)
        {
            var dbEmployee = await _context.Payments.FindAsync(id);
            if (dbEmployee != null)
            {
                dbEmployee.PId = payment.PId;
                dbEmployee.PType = payment.PType;
                dbEmployee.PDatCoc = payment.PDatCoc;
                dbEmployee.PAmout = payment.PAmout;
                dbEmployee.PStatus = payment.PStatus;


                await _context.SaveChangesAsync();
            }

            return dbEmployee;
        }
    }
}
