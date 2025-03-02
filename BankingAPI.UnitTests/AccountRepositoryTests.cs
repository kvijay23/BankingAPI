using BankingAPI.Domain.Entities;
using BankingAPI.Interfaces;
using Moq;

namespace BankingAPI.UnitTests
{
    public class AccountRepositoryTests
    {
        private readonly Mock<IAccountRepository> _mockAccountRepository;

        public AccountRepositoryTests()
        {
            _mockAccountRepository = new Mock<IAccountRepository>();
        }

        [Fact]
        public async Task GetAccounts_ShouldReturnListOfAccounts()
        {
            // Arrange
            var accounts = new List<CustomerAccount>
                {
                    new CustomerAccount { Id = 1, CustomerNo = 1, AccountTypeId = 1, IsActive = true, CreatedAt = DateTime.Now },
                    new CustomerAccount { Id = 2, CustomerNo = 2, AccountTypeId = 2, IsActive = true, CreatedAt = DateTime.Now }
                };
            _mockAccountRepository.Setup(repo => repo.GetAccounts()).ReturnsAsync(accounts);

            // Act
            var result = await _mockAccountRepository.Object.GetAccounts();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.First().CustomerNo);
        }

        [Fact]
        public async Task GetAccountById_ShouldReturnAccount()
        {
            var account = new CustomerAccount { Id = 1, CustomerNo = 1, AccountTypeId = 1, IsActive = true, CreatedAt = DateTime.Now };
            _mockAccountRepository.Setup(repo => repo.GetAccountById(1)).ReturnsAsync(account);

            var result = await _mockAccountRepository.Object.GetAccountById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.CustomerNo);
        }

        [Fact]
        public async Task CreateAccount_ShouldReturnAccountId()
        {
            var account = new CustomerAccount { Id = 1, CustomerNo = 1, AccountTypeId = 1, IsActive = true, CreatedAt = DateTime.Now };
            _mockAccountRepository.Setup(repo => repo.CreateAccount(account)).ReturnsAsync(1);

            var result = await _mockAccountRepository.Object.CreateAccount(account);

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task DisableAccount_ShouldReturnTrue()
        {
            _mockAccountRepository.Setup(repo => repo.FreezeAccount(1)).ReturnsAsync(true);

            var result = await _mockAccountRepository.Object.FreezeAccount(1);

            Assert.True(result);
        }
    }
}