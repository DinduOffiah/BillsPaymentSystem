using BillsPaymentSystem.DAL.Data;
using BillsPaymentSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BillsPaymentSystem.Core.Services
{
    public class BillServices : IBillService
    {
        private readonly BillPaymentDbContext _context;

        public BillServices(BillPaymentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bill>> GetBillsAsync()
        {
            var bills = await _context.Bills.ToListAsync();
            return bills;
        }

        public async Task<Bill> GetBillsByIdAsync(int id)
        {
            var bill = await _context.Bills.FirstOrDefaultAsync(d => d.BillID == id);
            return bill;
        }
    }
}
