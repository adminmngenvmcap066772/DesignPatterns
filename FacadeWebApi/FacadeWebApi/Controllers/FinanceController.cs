using Microsoft.AspNetCore.Mvc;
using FacadeWebApi.Finance;

namespace FacadeWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceController : ControllerBase
    {
        // The FinanceFacade provides a unified interface to multiple finance-related subsystems.
        // This allows the controller to interact with complex logic (loan, credit, investment)
        // through a single, simple API, improving maintainability and reducing coupling.
        private readonly FinanceFacade _facade;

        public FinanceController()
        {
            // Instead of instantiating and managing multiple subsystem services (LoanService, CreditService, InvestmentService),
            // we only need to work with the Facade. This simplifies the controller code.
            _facade = new FinanceFacade();
        }

        // GET /Finance/demo?customerId=abc&loanPrincipal=10000&loanRate=5&loanYears=5&investmentAmount=5000&investmentRate=7&investmentYears=5
        [HttpGet("demo")]
        public ActionResult<FinanceSummary> GetDemo(
            string customerId = "abc",
            decimal loanPrincipal = 10000,
            double loanRate = 5,
            int loanYears = 5,
            decimal investmentAmount = 5000,
            double investmentRate = 7,
            int investmentYears = 5)
        {
            // Without the Facade pattern, the controller would need to directly interact with each subsystem:
            //   - Call CreditService to get the credit score
            //   - Call LoanService to calculate the loan payment
            //   - Call InvestmentService to calculate future value
            // This would make the controller more complex and harder to maintain.

            // By using the Facade, we delegate all those interactions to a single method call.
            // The Facade coordinates the subsystems and returns a simple summary object.
            var summary = _facade.GetFinanceSummary(customerId, loanPrincipal, loanRate, loanYears, investmentAmount, investmentRate, investmentYears);
            return Ok(summary);
        }
    }
}
