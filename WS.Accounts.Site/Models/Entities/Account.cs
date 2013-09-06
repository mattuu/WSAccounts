using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WS.Accounts.Site.Models.Entities
{
    public class Account
    {
        public Account()
        {
            Transactions = new Collection<Transaction>();
        }

        public int AccountId { get; set; }

        public string Description { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}