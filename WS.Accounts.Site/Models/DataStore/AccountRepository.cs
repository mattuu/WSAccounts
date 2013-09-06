using WS.Accounts.Site.Models.Entities;

namespace WS.Accounts.Site.Models.DataStore
{
    public class AccountRepository : InMemoryRepository<Account>
    {
        public AccountRepository()
        {
            var accounts = new[]
                {
                    new Account
                    {
                        AccountId = 1,
                        Description = "W&S Accountancy Fee"
                    },
                    new Account
                    {
                        AccountId = 2,
                        Description = "Business Insurance"
                    },
                    new Account
                    {
                        AccountId = 3,
                        Description = "Meals"
                    },
                    new Account
                    {
                        AccountId = 4,
                        Description = "Mileage"
                    },
                    new Account
                    {
                        AccountId = 5,
                        Description = "Telephone Charges"
                    }
                };

            foreach (var a in accounts)
            {
                Add(a);
            }
        }
    }
}