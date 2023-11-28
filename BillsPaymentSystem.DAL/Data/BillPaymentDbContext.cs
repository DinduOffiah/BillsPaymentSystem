using BillsPaymentSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BillsPaymentSystem.DAL.Data
{
    public class BillPaymentDbContext : DbContext
    {
        public BillPaymentDbContext(DbContextOptions<BillPaymentDbContext> options)
          : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
