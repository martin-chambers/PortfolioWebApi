using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using PortfolioWebAPI.Models;

namespace PortfolioWebAPI.DataAccess
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TransactionConfiguration());
        }
        public class TransactionConfiguration : EntityTypeConfiguration<Transaction>
        {
            public TransactionConfiguration()
            {
                Property(t => t.Name).IsRequired();
                Property(t => t.TransactionId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(t => t.Price).HasPrecision(10, 6);
                Property(t => t.CashValue).HasPrecision(10, 6);
                Property(t => t.Commission).HasPrecision(4, 2);
                Property(t => t.Name).HasMaxLength(50);
                Property(t => t.Symbol).HasMaxLength(10);
                Property(t => t.Type).IsRequired();
            }
        }
        public PortfolioContext() : base("name=PortfolioContextConnectionString") { }
    }

}