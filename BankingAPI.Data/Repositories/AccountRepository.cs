using BankingAPI.Interfaces;
using BankingAPI.Domain.Entities;
using System.Data;
using Dapper;

namespace BankingAPI.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbConnection _db;

        public AccountRepository(IDbConnection db) => _db = db;

        public async Task<IEnumerable<CustomerAccount>> GetAccounts()
        {
            return await _db.QueryAsync<CustomerAccount>("SELECT * FROM CustomerAccount");
        }

        public async Task<int> CreateAccount(CustomerAccount account) =>
            await _db.ExecuteAsync("INSERT INTO CustomerAccount (CustomerNo, AccountTypeId, IsActive, CreatedAt) VALUES (@CustomerNo, @AccountTypeId, @IsActive, @CreatedAt)", account);

        public async Task<bool> FreezeAccount(int accountId) =>
            await _db.ExecuteAsync("UPDATE CustomerAccount SET IsActive = 0 WHERE Id = @Id", new { Id = accountId }) > 0;

        public async Task<CustomerAccount?> GetAccountById(int accountId) =>
            await _db.QueryFirstOrDefaultAsync<CustomerAccount>("SELECT * FROM CustomerAccount WHERE Id = @Id", new { Id = accountId });
    }
}
