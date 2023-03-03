using SanSoftInfoTech.Models;

namespace SanSoftInfoTech.ViewModels
{
    public class ProfileVM
    {
        public required User CurrentUser { get; set; }
        public List<MiniInvoiceVM>? MiniInvoiceVMs { get; set; }
    }
}
