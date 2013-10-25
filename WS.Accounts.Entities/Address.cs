using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Accounts.Entities
{
    public class Address
    {
        public int AddressId { get; set; }

        public int CustomerId { get; set; }

        public virtual Company Customer { get; set; }

        public string HouseNo { get; set; }

        public string StreetName { get; set; }

        public string AdditionalAddressLine { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string PostCode { get; set; }
    }
}
