using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanSoftInfoTech.Models
{
    public class LineItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(1000)]
        public string? Description { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }


        [ForeignKey("InvoiceNumber")]
        public Invoice? Invoice { get; set; }
        public int InvoiceNumber { get; set; }
    }
}
