// The LoanMediator class coordinates the loan approval process among multiple loan officers.
// It collects decisions and determines the final approval status based on majority vote.
using MediatorWebApi.MediatorPattern.Loans;

namespace MediatorWebApi.MediatorPattern.Loans
{
    public class LoanMediator : ILoanMediator
    {
        private readonly List<LoanOfficer> _officers;
        private readonly Dictionary<LoanApplication, List<bool>> _decisions;
        private readonly int _requiredVotes;

        public LoanMediator(List<LoanOfficer> officers)
        {
            _officers = officers;
            _decisions = new Dictionary<LoanApplication, List<bool>>();
            _requiredVotes = officers.Count;
        }

        // Called by a loan officer to submit their decision
        public void NotifyDecision(LoanOfficer sender, LoanApplication application, bool approved)
        {
            if (!_decisions.ContainsKey(application))
                _decisions[application] = new List<bool>();
            _decisions[application].Add(approved);

            // If all officers have voted, determine the result
            if (_decisions[application].Count == _requiredVotes)
            {
                int approvals = _decisions[application].Count(x => x);
                application.IsApproved = approvals > _requiredVotes / 2;
            }
        }
    }
}
