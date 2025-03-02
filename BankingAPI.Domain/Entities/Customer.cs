namespace BankingAPI.Domain.Entities
{
    public class Customer
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
