using FluentValidation;
using FluentValidationWebApp.Models;

// This validator enforces business rules for a loan application in a finance scenario.
namespace FluentValidationWebApp.Validators
{
    public class LoanApplicationValidator : AbstractValidator<LoanApplicationModel>
    {
        public LoanApplicationValidator()
        {
            // Applicant name is required
            RuleFor(x => x.ApplicantName)
                .NotEmpty().WithMessage("Applicant name is required.");

            // Amount must be between 1,000 and 1,000,000
            RuleFor(x => x.Amount)
                .InclusiveBetween(1000, 1_000_000)
                .WithMessage("Loan amount must be between $1,000 and $1,000,000.");

            // Term must be between 6 and 360 months
            RuleFor(x => x.TermMonths)
                .InclusiveBetween(6, 360)
                .WithMessage("Term must be between 6 and 360 months.");

            // Interest rate must be positive and less than 100
            RuleFor(x => x.InterestRate)
                .GreaterThan(0).WithMessage("Interest rate must be positive.")
                .LessThan(100).WithMessage("Interest rate must be less than 100%.");
        }
    }
}
