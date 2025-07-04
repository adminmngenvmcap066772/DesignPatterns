using Microsoft.AspNetCore.Mvc;

namespace LoanApplicationWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanApplicationController : ControllerBase
    {
        private readonly ILogger<LoanApplicationController> _logger;

        public LoanApplicationController(ILogger<LoanApplicationController> logger)
        {
            _logger = logger;
        }

        // POST endpoint to submit a loan application
        // This demonstrates model validation using FluentValidation in a financial context.
        [HttpPost]
        public IActionResult SubmitLoanApplication([FromBody] LoanApplication application)
        {
            // If the model is invalid, ASP.NET Core with FluentValidation will automatically return a 400 response.
            // If valid, you could process the application (e.g., save to database, calculate payments, etc.)

            // For demonstration, calculate the total interest to be paid over the loan term
            decimal totalInterest = application.LoanAmount * (application.InterestRate / 100) * application.TermYears;

            // Return a response with the calculated interest
            return Ok(new
            {
                Message = $"Loan application for {application.ApplicantName} received.",
                TotalInterest = totalInterest
            });
        }
    }
}
