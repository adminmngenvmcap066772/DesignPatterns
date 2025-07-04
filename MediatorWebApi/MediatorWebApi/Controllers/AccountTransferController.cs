using Microsoft.AspNetCore.Mvc;
using MediatorWebApi.MediatorPattern.Accounts;

namespace MediatorWebApi.Controllers
{
    /*
    The AccountTransferController demonstrates the Mediator pattern in a financial context.
    It coordinates transfers between a checking and a savings account using an AccountMediator.
    The controller does not handle the transfer logic directly; instead, it delegates coordination to the mediator and account classes.
    This approach keeps the controller clean and focused on handling HTTP requests.
    */
    [ApiController]
    [Route("[controller]")]
    public class AccountTransferController : ControllerBase
    {
        // The mediator coordinates communication between accounts
        private readonly IMediator _mediator;
        // Example accounts for demonstration
        private readonly CheckingAccount _checking;
        private readonly SavingsAccount _savings;

        public AccountTransferController()
        {
            // In a real application, use dependency injection and persistent storage for accounts
            _mediator = new AccountMediator();
            _checking = new CheckingAccount("Checking", 1000m, _mediator);
            _savings = new SavingsAccount("Savings", 500m, _mediator);
        }

        /// <summary>
        /// Transfers funds from checking to savings account using the mediator.
        /// The mediator is notified of the transfer, which could trigger additional business logic.
        /// </summary>
        /// <param name="amount">Amount to transfer</param>
        /// <returns>Balances after transfer</returns>
        [HttpPost("transfer")]
        public IActionResult Transfer([FromQuery] decimal amount)
        {
            // Initiate the transfer via the CheckingAccount, which uses the mediator
            _checking.TransferTo(_savings, amount);
            // Return the updated balances for both accounts
            return Ok(new
            {
                CheckingBalance = _checking.Balance,
                SavingsBalance = _savings.Balance
            });
        }
    }
}
