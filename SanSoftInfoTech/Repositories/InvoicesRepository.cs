using Microsoft.EntityFrameworkCore;
using SanSoftInfoTech.Data;
using SanSoftInfoTech.Models;
using SanSoftInfoTech.Services;
using SanSoftInfoTech.ViewModels;

namespace SanSoftInfoTech.Repositories
{
    public class InvoicesRepository : IInvoicesRepository
    {
        private readonly AppDbContext _dbContext;


        public InvoicesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> AddInvoiceToDatabaseAsync(Invoice newInvoice)
        {
            await _dbContext.Invoices.AddAsync(newInvoice);
            await _dbContext.SaveChangesAsync();

            return newInvoice.InvoiceNumber;
        }

        public async Task<Invoice?> GetInvoiceAsync(int invoiceNumber)
        {
            var targetInvoice = await _dbContext.Invoices
                    .Include(inv => inv.LineItems)    
                    .FirstOrDefaultAsync(inv => inv.InvoiceNumber == invoiceNumber);
            
            return targetInvoice;
        }

        public IEnumerable<MiniInvoiceVM>? GetUsersInvoices(int userId)
        {
            return _dbContext.Invoices
                                .Where(inv => inv.UserId == userId)
                                .Select(invoiceEntity =>
                                    new MiniInvoiceVM
                                    {
                                        InvoiceNumber = invoiceEntity.InvoiceNumber,
                                        CustomerName = invoiceEntity.CustomerName,
                                        CustomerAddress = invoiceEntity.CustomerAddress,
                                        CustomerEmail = invoiceEntity.CustomerEmail,
                                        CustomerPhone = invoiceEntity.CustomerPhone,
                                        Total = invoiceEntity.Total
                                    }
                                );
        }

    }
}
