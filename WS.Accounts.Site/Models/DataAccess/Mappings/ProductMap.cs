using System.Data.Entity.ModelConfiguration;
using WS.Accounts.Site.Models.Entities;

namespace WS.Accounts.Site.Models.DataAccess.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasKey(p => p.ProductId);

            HasMany(p => p.Transactions)
                .WithRequired(t => t.Product)
                .HasForeignKey(t => t.ProductId);
        }
    }
}