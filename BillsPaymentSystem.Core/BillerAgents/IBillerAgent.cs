using BillsPaymentSystem.API.DTO;
using BillsPaymentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.Core.BillerAgents
{
    public interface IBillerAgent
    {
        Task<IEnumerable<Bill>> GetBills();
        Task SubmitPayment(PaymentDto payment);
    }
}
