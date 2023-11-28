using BillsPaymentSystem.DAL.Models;

namespace BillsPaymentSystem.Core.Services
{
    public interface IBillService
    {
        Task<IEnumerable<Bill>> GetBillsAsync();
        Task<Bill> GetBillsByIdAsync(int id);
    }
}
