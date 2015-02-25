using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WS.Accounts.Entities
{
    public class Account : EntityBase
    {
        public Account()
        {
            Init();
        }

        public int AccountId { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public string Description { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        private void Init()
        {
            Transactions = new Collection<Transaction>();
        }
    }
}