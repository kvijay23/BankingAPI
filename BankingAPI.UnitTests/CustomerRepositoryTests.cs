using BankingAPI.Domain.Entities;
using BankingAPI.Interfaces;
using Moq;

namespace BankingAPI.UnitTests
{
    public class CustomerRepositoryTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;

        public CustomerRepositoryTests()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
        }

        [Fact]
        public async Task GetCustomers_ShouldReturnListOfCustomers()
        {
            var customers = new List<Customer>
        {
            new Customer { CustomerNo = 1, CustomerName = "John Doe", Address = "123 Main St", PostCode = "12345", City = "Anytown", Country = "USA", IsActive = true },
            new Customer { CustomerNo = 2, CustomerName = "Jane Smith", Address = "456 Elm St", PostCode = "67890", City = "Othertown", Country = "USA", IsActive = true }
        };
            _mockCustomerRepository.Setup(repo => repo.GetCustomers()).ReturnsAsync(customers);

            var result = await _mockCustomerRepository.Object.GetCustomers();

            Assert.Equal(2, result.Count());
            Assert.Equal("John Doe", result.First().CustomerName);
        }

        [Fact]
        public async Task GetCustomerById_ShouldReturnCustomer()
        {
            var customer = new Customer { CustomerNo = 1, CustomerName = "John Doe", Address = "123 Main St", PostCode = "12345", City = "Anytown", Country = "USA", IsActive = true };
            _mockCustomerRepository.Setup(repo => repo.GetCustomerById(1)).ReturnsAsync(customer);

            var result = await _mockCustomerRepository.Object.GetCustomerById(1);

            Assert.NotNull(result);
            Assert.Equal("John Doe", result.CustomerName);
        }

        [Fact]
        public async Task CreateCustomer_ShouldReturnCustomerId()
        {
            var customer = new Customer { CustomerNo = 1, CustomerName = "John Doe", Address = "123 Main St", PostCode = "12345", City = "Anytown", Country = "USA", IsActive = true };
            _mockCustomerRepository.Setup(repo => repo.CreateCustomer(customer)).ReturnsAsync(1);

            var result = await _mockCustomerRepository.Object.CreateCustomer(customer);

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task DisableCustomer_ShouldReturnTrue()
        {
            _mockCustomerRepository.Setup(repo => repo.DisableCustomer(1)).ReturnsAsync(true);

            var result = await _mockCustomerRepository.Object.DisableCustomer(1);

            Assert.True(result);
        }
    }

}