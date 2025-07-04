// The LoanOfficer class represents a colleague in the Mediator pattern.
// Each loan officer can review a loan application and notify the mediator of their decision.
using MediatorWebApi.MediatorPattern.Loans;

namespace MediatorWebApi.MediatorPattern.Loans
{
    public class LoanOfficer
    {
        private readonly ILoanMediator _mediator;
        public string Name { get; }

        public LoanOfficer(string name, ILoanMediator mediator)
        {
            Name = name;
            _mediator = mediator;
        }

        // Review the application and notify the mediator of the decision
        public void ReviewApplication(LoanApplication application, bool approve)
        {
            _mediator.NotifyDecision(this, application, approve);
        }
    }
}
