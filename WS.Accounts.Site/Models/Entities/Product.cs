using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WS.Accounts.Site.Models.Entities
{
    public class Product
    {
        public Product()
        {
            Transactions = new Collection<Transaction>();
        }

        public int ProductId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}