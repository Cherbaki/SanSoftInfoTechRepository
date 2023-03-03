using SanSoftInfoTech.Models;
using SanSoftInfoTech.ViewModels;

namespace SanSoftInfoTech.Services
{
    public interface IInvoicesRepository
    {
        public Task<int> AddInvoiceToDatabaseAsync(Invoice newInvoice);
        public Task<Invoice?> GetInvoiceAsync(int invoiceNumber);
        public IEnumerable<MiniInvoiceVM>? GetUsersInvoices(int userId);


    }
}
