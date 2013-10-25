using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Accounts.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Position { get; set; }
    }
}
