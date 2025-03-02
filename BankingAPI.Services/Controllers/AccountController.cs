using BankingAPI.Domain.Entities;
using BankingAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerAccount>>> GetAccounts()
        {
            var accounts = await _accountRepository.GetAccounts();
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount([FromBody] CustomerAccount account)
        {
            var accountId = await _accountRepository.CreateAccount(account);
            return CreatedAtAction(nameof(GetAccountById), new { id = accountId }, account);
        }

        [HttpPut("{id}/freeze")]
        public async Task<ActionResult> FreezeAccount(int id)
        {
            var result = await _accountRepository.FreezeAccount(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerAccount>> GetAccountById(int id)
        {
            var account = await _accountRepository.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }
    }
}