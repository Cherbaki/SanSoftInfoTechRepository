using Microsoft.EntityFrameworkCore;
using SanSoftInfoTech.Models;

namespace SanSoftInfoTech.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


    }
}
