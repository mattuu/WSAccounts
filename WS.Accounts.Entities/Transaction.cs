using System;

namespace WS.Accounts.Entities
{
    public class Transaction : EntityBase
    {
        public int TransactionId { get; set; }

        public int AccountId { get; set; }

        public virtual Account Account { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string Reference { get; set; }

        public DateTime TransactionDateTime { get; set; }

        public decimal Amount { get; set; }

        public string Comment { get; set; }
    }
}