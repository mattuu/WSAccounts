using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Accounts.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public int AccountId { get; set; }

        public virtual Account Account { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string Reference { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
    }
}
