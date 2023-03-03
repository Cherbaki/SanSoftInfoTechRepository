namespace SanSoftInfoTech.ViewModels
{
    public class MiniInvoiceVM
    {
        public required int InvoiceNumber { get; set; }
        public required string CustomerName { get; set; }
        public required string CustomerAddress { get; set; }
        public required string CustomerEmail { get; set; }
        public required string CustomerPhone { get; set; }
        public decimal Total { get; set; }
    }
}
