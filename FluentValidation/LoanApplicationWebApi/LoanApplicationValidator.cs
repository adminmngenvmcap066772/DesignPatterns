using FluentValidation;

namespace LoanApplicationWebApi
{
    // This validator ensures that the LoanApplication model meets business rules.
    // It uses FluentValidation to enforce constraints such as required fields and valid ranges.
    // Demonstrates both synchronous and asynchronous validation in a financial context.
    public class LoanApplicationValidator : AbstractValidator<LoanApplication>
    {
        public LoanApplicationValidator()
        {
            // Applicant name must not be empty
            RuleFor(x => x.ApplicantName)
                .NotEmpty().WithMessage("Applicant name is required.");

            // Loan amount must be greater than zero
            RuleFor(x => x.LoanAmount)
                .GreaterThan(0).WithMessage("Loan amount must be greater than zero.");

            // Interest rate must be between 0 and 100 percent
            RuleFor(x => x.InterestRate)
                .InclusiveBetween(0, 100).WithMessage("Interest rate must be between 0 and 100.");

            // Term must be at least 1 year and no more than 40 years
            RuleFor(x => x.TermYears)
                .InclusiveBetween(1, 40).WithMessage("Term must be between 1 and 40 years.");

            // Async validation: Check if applicant is on a blacklist (simulated async check)
            RuleFor(x => x.ApplicantName)
                .MustAsync(async (name, cancellation) => !await IsBlacklistedAsync(name))
                .WithMessage("Applicant is blacklisted and cannot apply for a loan.");
        }

        // Simulate an asynchronous check against a blacklist (e.g., database or external API)
        // In a real financial application, this would query a data source.
        private async Task<bool> IsBlacklistedAsync(string applicantName)
        {
            // Simulated blacklist for demonstration
            var blacklistedNames = new[] { "John Doe", "Jane Black" };
            await Task.Delay(100); // Simulate async I/O
            return blacklistedNames.Contains(applicantName);
        }
    }
}
