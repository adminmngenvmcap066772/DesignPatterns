using Microsoft.AspNetCore.Mvc;
using MediatorWebApi.MediatorPattern.Loans;

namespace MediatorWebApi.Controllers
{
    // This controller demonstrates the Mediator pattern in a loan approval scenario.
    // Multiple loan officers review a loan application, and the mediator coordinates their decisions.
    [ApiController]
    [Route("[controller]")]
    public class LoanApprovalController : ControllerBase
    {
        [HttpPost("review")]
        public IActionResult ReviewLoan([FromQuery] string applicant, [FromQuery] decimal amount)
        {
            // Create a loan application
            var application = new LoanApplication(applicant, amount);

            // Create the mediator and loan officers
            var officers = new List<LoanOfficer>();
            var mediator = new LoanMediator(officers);
            officers.Add(new LoanOfficer("Officer A", mediator));
            officers.Add(new LoanOfficer("Officer B", mediator));
            officers.Add(new LoanOfficer("Officer C", mediator));

            // Each officer reviews the application (simulate decisions)
            officers[0].ReviewApplication(application, true);  // Approve
            officers[1].ReviewApplication(application, false); // Reject
            officers[2].ReviewApplication(application, true);  // Approve

            // The mediator determines the result based on majority
            return Ok(new
            {
                Applicant = application.ApplicantName,
                Amount = application.Amount,
                Approved = application.IsApproved
            });
        }
    }
}
