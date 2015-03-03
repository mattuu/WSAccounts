using System;
using System.Collections.Generic;
using System.Linq;
using WS.Accounts.DataAccess;
using WS.Accounts.Entities;

namespace WS.Accounts.Import
{
    public interface IAccountFactory<in T>
    {
        IEnumerable<Account> Create(IPaidRow row);
    }

    public abstract class AccountFactory<T> : IAccountFactory<T>
    {
        private readonly IAccountStore _accountStore;
        private readonly int _companyId;

        protected AccountFactory(IAccountStore accountStore, int companyId)
        {
            if (accountStore == null) throw new ArgumentNullException("accountStore");
            _accountStore = accountStore;
            _companyId = companyId;
        }

        private Account FindOrCreate(string name)
        {
            var account = _accountStore.GetAll()
                                       .SingleOrDefault(a => a.CompanyId == _companyId && a.Description == name);

            if (account == null)
            {
                account = new Account
                          {
                              CompanyId = _companyId,
                              CreatedOn = DateTime.Now,
                              CreatedBy = "IMPORT",
                              Balance = 0,
                              Description = name,
                          };

                _accountStore.Save(account);
                account = _accountStore.Get(account.AccountId);
            }

            return account;
        }

        private void AddTransaction(Account account, decimal transactionValue, DateTime transactionDateTime, string reference, string comment)
        {
            var transaction = new Transaction
                              {
                                  Account = account,
                                  Amount = transactionValue,
                                  TransactionDateTime = transactionDateTime,
                                  Reference = reference,
                                  CreatedBy = "IMPORT",
                                  CreatedOn = DateTime.Now,
                                  Comment = comment
                              };

            account.Transactions.Add(transaction);
            _accountStore.Save(account);
        }

        protected internal Account RegisterTransaction(string accountName, decimal transactionValue, DateTime transactionDateTime, string reference, string comment)
        {
            var account = FindOrCreate(accountName);
            
            AddTransaction(account, transactionValue, transactionDateTime, reference, comment);
            
            return account;
        }

        public abstract IEnumerable<Account> Create(IPaidRow row);
    }

    public class PaidRowAccountFactory : AccountFactory<IPaidRow>
    {
        public PaidRowAccountFactory(IAccountStore accountStore, int companyId) 
            : base(accountStore, companyId)
        {
        }

        public override IEnumerable<Account> Create(IPaidRow row)
        {
            var accounts = new List<Account>();

            if (row.AccountancyFees.HasValue)
            {
                accounts.Add(RegisterTransaction("Accountancy Fees", row.AccountancyFees.Value, row.Date, row.Reference, row.Details));
            }
            if (row.BankCharges.HasValue)
            {
                accounts.Add(RegisterTransaction("Bank Charges", row.BankCharges.Value, row.Date, row.Reference, row.Details));
            }

            return accounts;
        }
    }
}