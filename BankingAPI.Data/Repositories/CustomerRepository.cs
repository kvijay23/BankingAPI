using BankingAPI.Domain.Entities;
using BankingAPI.Interfaces;
using Dapper;
using System.Data;

namespace BankingAPI.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _db;

        public CustomerRepository(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Customer>> GetCustomers() =>
            await _db.QueryAsync<Customer>("SELECT * FROM Customer");

        public async Task<Customer?> GetCustomerById(int customerNo) =>
            await _db.QueryFirstOrDefaultAsync<Customer>("SELECT * FROM Customer WHERE CustomerNo = @CustomerNo", new { CustomerNo = customerNo });

        public async Task<int> CreateCustomer(Customer customer) =>
            await _db.ExecuteAsync("INSERT INTO Customer (CustomerName, Address, PostCode, City, Country, IsActive) VALUES (@CustomerName, @Address, @PostCode, @City, @Country, @IsActive)", customer);

        public async Task<bool> DisableCustomer(int customerNo) =>
            await _db.ExecuteAsync("UPDATE Customer SET IsActive = 0 WHERE CustomerNo = @CustomerNo", new { CustomerNo = customerNo }) > 0;
    }
}
