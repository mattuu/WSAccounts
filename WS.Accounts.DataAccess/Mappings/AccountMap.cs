using System.Data.Entity.ModelConfiguration;
using WS.Accounts.Entities;

namespace WS.Accounts.DataAccess.Mappings
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            HasKey(a => a.AccountId);

            HasMany(a => a.Transactions)
                .WithRequired(t => t.Account)
                .HasForeignKey(t => t.AccountId);
        }
    }
}