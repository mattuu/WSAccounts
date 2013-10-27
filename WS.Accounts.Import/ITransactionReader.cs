using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Accounts.Entities;

namespace WS.Accounts.Import
{
    public interface ITransactionReader
    {
        void Import(Stream stream);

        IEnumerable<Account> GetAccounts();

        IEnumerable<Transaction> GetTransactions();

        int GetProgress();
    }
}
