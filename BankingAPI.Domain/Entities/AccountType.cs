namespace BankingAPI.Domain.Entities
{
    public class AccountType
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
    }
}
