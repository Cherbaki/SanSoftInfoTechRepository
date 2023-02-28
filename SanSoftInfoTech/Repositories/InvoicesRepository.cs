using SanSoftInfoTech.Data;
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




    }
}
