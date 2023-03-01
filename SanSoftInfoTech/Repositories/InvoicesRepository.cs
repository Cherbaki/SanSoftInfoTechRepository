using SanSoftInfoTech.Data;
using SanSoftInfoTech.Models;
using SanSoftInfoTech.Services;

namespace SanSoftInfoTech.Repositories
{
    public class InvoicesRepository : IInvoicesRepository
    {
        private readonly AppDbContext _dbContext;


        public InvoicesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddInvoiceToDatabase(Invoice newInvoice)
        {
            await _dbContext.Invoices.AddAsync(newInvoice);
            await _dbContext.SaveChangesAsync();
        }

    }
}
