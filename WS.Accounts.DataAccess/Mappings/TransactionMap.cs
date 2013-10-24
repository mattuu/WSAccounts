using System.Data.Entity.ModelConfiguration;
using WS.Accounts.Entities;

namespace WS.Accounts.DataAccess
{
    public class TransactionMap : EntityTypeConfiguration<Transaction>
    {
        public TransactionMap()
        {
            HasKey(t => t.TransactionId);

            HasRequired(t => t.Account)
                .WithMany()
                .HasForeignKey(t => t.AccountId);

            HasRequired(t => t.Product)
                .WithMany()
                .HasForeignKey(t => t.ProductId);
        }
    }
}