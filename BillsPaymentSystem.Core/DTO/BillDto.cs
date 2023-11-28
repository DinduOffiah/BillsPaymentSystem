using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.API.DTO
{
    public class BillDto
    {
        public int BillID { get; set; }
        public string? BillName { get; set; }
        public double Amount { get; set; }
    }
}
