namespace WS.Accounts.Entities
{
    public class Address : EntityBase
    {
        public int AddressId { get; set; }

        public int CustomerId { get; set; }

        public virtual Company Customer { get; set; }

        public string HouseNo { get; set; }

        public string StreetName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string PostCode { get; set; }
    }
}