namespace BankingAPI.Domain.Entities
{
    public class CustomerAccount
    {
        public int Id { get; set; }
        public int CustomerNo { get; set; }
        public int AccountTypeId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
