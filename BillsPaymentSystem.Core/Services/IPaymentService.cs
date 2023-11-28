using BillsPaymentSystem.API.DTO;
using BillsPaymentSystem.DAL.Models;

namespace BillsPaymentSystem.Core.Services
{
    public interface IPaymentService
    {
        Task PayBillAsync(PaymentDto payment);

        Task<IEnumerable<Payment>> GetPaymentHistoryAsync();
    }
}
