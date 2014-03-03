using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Accounts.DataAccess.Mappings;
using WS.Accounts.Entities;

namespace WS.Accounts.DataAccess
{
    public class AccountsContext : DbContext
    {
        public AccountsContext()
            : this("WSAccounts")
        {
        }

        public AccountsContext(string connectionStringName)
            : base(connectionStringName)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new TransactionMap());
        }

        public IDbSet<Transaction> Transactions { get; set; }

        public IDbSet<Account> Accounts { get; set; }

        public IDbSet<Product> Products { get; set; }
    }
}
