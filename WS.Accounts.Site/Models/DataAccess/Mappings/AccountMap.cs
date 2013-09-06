using System.Data.Entity.ModelConfiguration;
using WS.Accounts.Site.Models.Entities;

namespace WS.Accounts.Site.Models.DataAccess.Mappings
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