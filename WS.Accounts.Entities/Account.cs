using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Accounts.Entities
{
    public class Account
    {
        public int AccountId { get; set; }

        public string Description { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
