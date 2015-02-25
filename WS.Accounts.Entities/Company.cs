using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WS.Accounts.Entities
{
    public class Company : EntityBase
    {
        public Company()
        {
            Init();
        }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public DateTime RegisteredDate { get; set; }

        public string VatRegNumber { get; set; }

        public string CompanyNubmer { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        private void Init()
        {
            Accounts = new Collection<Account>();
            Addresses = new Collection<Address>();
            Employees = new Collection<Employee>();
        }
    }
}