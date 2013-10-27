using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Accounts.Import
{
    public interface IReceivedRow
    {
        DateTime Date { get; }

        string Reference { get; }

        string Details { get; }

        decimal? CurrentAccount { get; }

        decimal? SavingsAccount { get; }

        decimal VatWithin { get; }

        decimal Fees { get; }

        decimal? BankInterest { get; }

        decimal? Miscellaneous { get; }

        decimal? BankTransfers { get; }

        decimal? Other { get; }
    }
}
