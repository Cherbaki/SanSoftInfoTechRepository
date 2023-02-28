using Microsoft.AspNetCore.Mvc;
using SanSoftInfoTech.Models;
using System.ComponentModel.DataAnnotations;

namespace SanSoftInfoTech.ViewModels
{
    public class CreateInvoiceVM
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

        public required string LineItemsJSON { get; set; }
    }
}
