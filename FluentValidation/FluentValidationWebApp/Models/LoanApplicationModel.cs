// This model represents a simple loan application for a finance scenario.
namespace FluentValidationWebApp.Models
{
    public class LoanApplicationModel
    {
        public string ApplicantName { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public decimal InterestRate { get; set; }
    }
}
