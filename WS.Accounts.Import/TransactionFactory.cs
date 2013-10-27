using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Accounts.Entities;

namespace WS.Accounts.Import
{
    public class TransactionFactory
    {
        private IEnumerable<Account> _accounts;

        public TransactionFactory(IEnumerable<Account> accounts)
        {
            _accounts = accounts;
        }

        public IEnumerable<Transaction> Create(IPaidRow row)
        {
            var result = new Collection<Transaction>();

            if (row.AccountancyFees.HasValue)
            {

            }

            return result;
        }

        //private Transaction GetFromRow(Func<IPaidRow, )
        //{
        //    return new 
        //}
    }
}
