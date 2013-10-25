using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Accounts.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public DateTime RegisteredDate { get; set; }

        public string VatRegNumber { get; set; }

        public string CompanyNubmer { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}


