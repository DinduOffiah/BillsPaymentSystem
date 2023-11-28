using BillsPaymentSystem.API.DTO;
using BillsPaymentSystem.DAL.Data;
using BillsPaymentSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly BillPaymentDbContext _context;

        public PaymentService(BillPaymentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetPaymentHistoryAsync()
        {
            var history = await _context.Payments.Include(p => p.Bill).OrderByDescending(p => p.PaymentDate).ToListAsync();
            return history;
        }

        public async Task PayBillAsync(PaymentDto payment)
        {
            var payments = new Payment();
            payments.BillID = payment.BillID;
            payments.Amount = payment.Amount;
            payments.PaymentDate = payment.PaymentDate;
            await _context.Payments.AddAsync(payments);
            await _context.SaveChangesAsync();
        }
    }
}
