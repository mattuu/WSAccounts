using System.Data.Entity.ModelConfiguration;
using WS.Accounts.Entities;

namespace WS.Accounts.DataAccess
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasKey(p => p.ProductId);
        }
    }
}