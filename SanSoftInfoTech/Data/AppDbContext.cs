using Microsoft.EntityFrameworkCore;
using SanSoftInfoTech.Models;
using SanSoftInfoTech.ViewModels;

namespace SanSoftInfoTech.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<LineItem> LineItems { get; set; } 


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LineItem>()
                .HasOne(li => li.Invoice)
                .WithMany(i => i.LineItems)
                .HasForeignKey(li => li.InvoiceNumber);

        }


        public DbSet<SanSoftInfoTech.ViewModels.CreateInvoiceVM> CreateInvoiceVM { get; set; } = default!;

    }
}
