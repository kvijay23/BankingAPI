using BankingAPI.Domain.Entities;
using BankingAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody] Customer customer)
        {
            var customerId = await _customerRepository.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customerId }, customer);
        }

        [HttpPut("{id}/disable")]
        public async Task<ActionResult> DisableCustomer(int id)
        {
            var result = await _customerRepository.DisableCustomer(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
