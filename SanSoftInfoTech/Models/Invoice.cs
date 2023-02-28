using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanSoftInfoTech.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceNumber { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CustomerName { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CustomerAddress { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CustomerEmail { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CustomerPhone { get; set; }
        [Required]
        public decimal Subtotal { get; set; }
        [Required]
        public decimal Taxes { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Status { get; set; }
        

        [NotMapped]
        public ICollection<LineItem>? LineItems { get; set; }
    }
}
