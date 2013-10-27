using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Accounts.Entities;

namespace WS.Accounts.Import
{
    public class AccountFactory
    {
        public AccountFactory()
        {

        }

        public Account Create(string name)
        {
            return new Account
            {
                Balance = 0,
                Description = name,
            };
        }
    }
}
