using System.Data.Entity;
using WS.Accounts.Site.Models.DataAccess.Mappings;
using WS.Accounts.Site.Models.Entities;

namespace WS.Accounts.Site.Models.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Product> Products { get; set; }

        public DatabaseContext() : base("WSAccounts")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new TransactionMap());
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}