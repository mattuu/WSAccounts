using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Accounts.Entities
{
    public class Account
    {
        public Account()
        {
            Init();
        }

        public int AccountId { get; set; }

        public string Description { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        private void Init()
        {
            Transactions = new Collection<Transaction>();
        }
    }
}
