using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillsPaymentSystem.DAL.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        [Required]
        public int BillID { get; set; }
        [Required]
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [ForeignKey("BillID")]
        [BindNever]
        public Bill? Bill { get; set; }
    }
}
