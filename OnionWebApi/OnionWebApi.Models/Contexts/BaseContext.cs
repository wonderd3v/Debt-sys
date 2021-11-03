using Microsoft.EntityFrameworkCore;
using OnionWebApi.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionWebApi.Models.Contexts
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> contextOptions) : base(contextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }  
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Loan>()
                    .HasOne(m => m.Debtor)
                    .WithMany(t => t.DebtorLoans)
                    .IsRequired()
                    .HasForeignKey(m => m.DebtorId)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Loan>()
                    .HasOne(m => m.Creditor)
                    .WithMany(t => t.CreditorLoans)
                    .IsRequired()
                    .HasForeignKey(m => m.CreditorId)
                    .OnDelete(DeleteBehavior.NoAction);

            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IBaseEntity).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }
        }
    }
}
