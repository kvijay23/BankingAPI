using BankingAPI.Domain.Entities;

namespace BankingAPI.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<CustomerAccount>> GetAccounts();
        Task<int> CreateAccount(CustomerAccount account);
        Task<bool> FreezeAccount(int accountId);
        Task<CustomerAccount?> GetAccountById(int accountId);
    }
}
