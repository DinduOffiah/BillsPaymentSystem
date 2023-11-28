using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.DAL.Models
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }
        [Required]
        [StringLength(100)]
        public string? BillName { get; set; }
        [Required]
        public double Amount { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; } = DateTime.Now;

        public ICollection<Payment>? Payments { get; set; }
    }
}
