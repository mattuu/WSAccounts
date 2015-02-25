using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace WS.Accounts.Services
{
    public interface IAccount
    {
        int AccountId { get; }

        string Description { get; set; }

        decimal Balance { get; set; }

        bool IsActive { get; set; }

        DateTime CreatedOn { get; set; }

        string CreatedBy { get; set; }

        DateTime? ModifiedOn { get; set; }

        string ModifiedBy { get; set; }
    }

    public interface ITransaction
    {
        int TransactionId { get; }

        int AccountId { get; }

        IAccount Account { get; }

        decimal Amount { get; set; }

        DateTime TransactionDateTime { get; set; }

        string Reference { get; set; }

        string Comment { get; set; }

        DateTime CreatedOn { get; set; }

        string CreatedBy { get; set; }

        DateTime? ModifiedOn { get; set; }

        string ModifiedBy { get; set; }
    }

    public interface IAccountService
    {
        IEnumerable<ITransaction> GetTransactionsByAccount(int accountId);

        IEnumerable<ITransaction> GetRecentTransactions(DateTime fromDate);

        decimal GetAccountBalance(int accountId);

        IEnumerable<ITransaction> GetRecentAccountTransactions(int accountId, DateTime fromDate);

        IAccount AddTransaction(int accountId, decimal amount, string reference, string comment);

        IAccount CreateAccount(string desciription);

        IAccount UpdateAccount(IAccount source);

        //IAccounnt 

        IEnumerable<IAccount> GetActiveAccounts();
    }

    public interface ITransactionFactory
    {
        ITransaction Create(int accountId, decimal amount, string reference, string comment);
    }

    public interface IAccountFactory
    {
        IAccount Create(string description);
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IRepository<IAccount> _accoutRepo;
        private readonly ITransactionFactory _transactionFactory;
        private readonly IRepository<ITransaction> _transactionRepo;
        private readonly string _username;

        public AccountService(IRepository<ITransaction> transactionRepo,
                              IRepository<IAccount> accoutRepo,
                              ITransactionFactory transactionFactory,
                              IAccountFactory accountFactory,
                              IPrincipal principal)
        {
            if (transactionRepo == null) throw new ArgumentNullException("transactionRepo");
            if (accoutRepo == null) throw new ArgumentNullException("accoutRepo");
            if (transactionFactory == null) throw new ArgumentNullException("transactionFactory");
            if (accountFactory == null) throw new ArgumentNullException("accountFactory");
            if (principal == null) throw new ArgumentNullException("principal");
            _transactionRepo = transactionRepo;
            _accoutRepo = accoutRepo;
            _transactionFactory = transactionFactory;
            _accountFactory = accountFactory;

            _username = principal.Identity.Name;
        }

        public IEnumerable<ITransaction> GetTransactionsByAccount(int accountId)
        {
            return _transactionRepo.Where(t => t.AccountId == accountId);
        }

        public IEnumerable<ITransaction> GetRecentTransactions(DateTime fromDate)
        {
            return _transactionRepo.Where(t => t.TransactionDateTime >= fromDate);
        }

        public decimal GetAccountBalance(int accountId)
        {
            var account = FindAccount(accountId);
            return account.Balance;
        }

        public IEnumerable<ITransaction> GetRecentAccountTransactions(int accountId, DateTime fromDate)
        {
            return _transactionRepo.Where(t => t.TransactionDateTime >= fromDate)
                                   .Where(t => t.AccountId == accountId);
        }

        public IAccount AddTransaction(int accountId, decimal amount, string reference, string comment)
        {
            var transaction = _transactionFactory.Create(accountId, amount, reference, comment);

            _transactionRepo.Add(transaction, true);

            var account = _accoutRepo.Find(accountId);
            account.Balance = GetAccountBalance(accountId);

            _accoutRepo.Update(account, true);

            return account;
        }

        public IAccount CreateAccount(string desciription)
        {
            var account = _accountFactory.Create(desciription);
            account.CreatedOn = DateTime.Now;
            account.CreatedBy = _username;

            _accoutRepo.Add(account, true);

            return account;
        }

        public IAccount UpdateAccount(IAccount source)
        {
            var target = FindAccount(source.AccountId);

            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.ModifiedBy = _username;
            target.ModifiedOn = DateTime.Now;

            _accoutRepo.Update(target, true);

            return target;
        }

        public IEnumerable<IAccount> GetActiveAccounts()
        {
            return _accoutRepo.Where(a => a.IsActive);
        }

        private IAccount FindAccount(int accountId)
        {
            var account = _accoutRepo.Find(accountId);
            if (account == null) throw new NullReferenceException(string.Format("Account not found for given ID {0}", accountId));
            return account;
        }
    }
}