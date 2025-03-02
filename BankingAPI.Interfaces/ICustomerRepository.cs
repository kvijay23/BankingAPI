using BankingAPI.Domain.Entities;

namespace BankingAPI.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer?> GetCustomerById(int customerNo);
        Task<int> CreateCustomer(Customer customer);
        Task<bool> DisableCustomer(int customerNo);
    }
}
