using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.API.DTO
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public int BillID { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
