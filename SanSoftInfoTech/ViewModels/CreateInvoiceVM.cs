using Microsoft.AspNetCore.Mvc;
using SanSoftInfoTech.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SanSoftInfoTech.ViewModels
{
    public class CreateInvoiceVM
    {
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
        [EmailAddress]
        public required string CustomerEmail { get; set; }
        [Required]
        public required int CustomerPhone { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Status { get; set; }
        [Required]
        public required decimal TaxValue { get; set; }

        public required string LineItemsJSON { get; set; }
    }
}
