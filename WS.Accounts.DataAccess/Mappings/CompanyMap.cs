using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Accounts.Entities;

namespace WS.Accounts.DataAccess.Mappings
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            HasKey(c => c.CompanyId);

            HasMany(c => c.Addresses)
                .WithRequired(a => a.Customer)
                .HasForeignKey(a => a.CustomerId);

            HasMany(c => c.Employees)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.CompanyId);

        }
    }
}
