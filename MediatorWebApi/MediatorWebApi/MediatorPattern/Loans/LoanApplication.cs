// The LoanApplication class represents a financial loan application.
// It contains applicant information and tracks the approval status.
namespace MediatorWebApi.MediatorPattern.Loans
{
    public class LoanApplication
    {
        public string ApplicantName { get; set; }
        public decimal Amount { get; set; }
        public bool? IsApproved { get; set; } // null = pending, true = approved, false = rejected
        public LoanApplication(string applicantName, decimal amount)
        {
            ApplicantName = applicantName;
            Amount = amount;
            IsApproved = null;
        }
    }
}
