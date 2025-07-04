// This model represents a loan application in a financial context.
// It includes properties such as applicant name, loan amount, and interest rate.
namespace LoanApplicationWebApi
{
    public class LoanApplication
    {
        // The name of the applicant applying for the loan
        public string ApplicantName { get; set; } = string.Empty;

        // The amount of money requested for the loan
        public decimal LoanAmount { get; set; }

        // The annual interest rate for the loan (as a percentage)
        public decimal InterestRate { get; set; }

        // The term of the loan in years
        public int TermYears { get; set; }
    }
}
