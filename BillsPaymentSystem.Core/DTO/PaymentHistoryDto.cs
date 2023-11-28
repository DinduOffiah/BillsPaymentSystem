using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.Core.DTO
{
    public class PaymentHistoryDto
    {
        public int PaymentID { get; set; }
        public string? BillName { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
