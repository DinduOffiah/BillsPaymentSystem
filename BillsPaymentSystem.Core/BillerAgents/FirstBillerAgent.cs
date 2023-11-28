using BillsPaymentSystem.API.DTO;
using BillsPaymentSystem.Core.Services;
using BillsPaymentSystem.DAL.Data;
using BillsPaymentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.Core.BillerAgents
{
    public class FirstBillerAgent : IBillerAgent
    {
        private readonly IBillService _billServices;
        private readonly IPaymentService _paymentServices;

        public FirstBillerAgent(IBillService service, IPaymentService services)
        {
            _billServices = service;
            _paymentServices = services;
        }

        public Task<IEnumerable<Bill>> GetBills()
        {
            return _billServices.GetBillsAsync();
        }

        public Task SubmitPayment(PaymentDto payment)
        {
            return _paymentServices.PayBillAsync(payment);
        }
    }
}
