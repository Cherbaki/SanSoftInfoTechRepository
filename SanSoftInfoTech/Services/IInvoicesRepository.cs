using SanSoftInfoTech.Models;

namespace SanSoftInfoTech.Services
{
    public interface IInvoicesRepository
    {
        public Task AddInvoiceToDatabase(Invoice newInvoice);
    }
}
