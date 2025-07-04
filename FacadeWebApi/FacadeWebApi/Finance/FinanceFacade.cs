// Facade class that provides a simplified interface to various finance subsystems.
namespace FacadeWebApi.Finance
{
    public class FinanceFacade
    {
        private readonly LoanService _loanService;
        private readonly CreditService _creditService;
        private readonly InvestmentService _investmentService;

        public FinanceFacade()
        {
            _loanService = new LoanService();
            _creditService = new CreditService();
            _investmentService = new InvestmentService();
        }

        // Simplified method to get a finance summary for a customer.
        public FinanceSummary GetFinanceSummary(string customerId, decimal loanPrincipal, double loanRate, int loanYears, decimal investmentAmount, double investmentRate, int investmentYears)
        {
            var creditScore = _creditService.GetCreditScore(customerId);
            var monthlyPayment = _loanService.CalculateMonthlyPayment(loanPrincipal, loanRate, loanYears);
            var futureValue = _investmentService.CalculateFutureValue(investmentAmount, investmentRate, investmentYears);
            return new FinanceSummary
            {
                CreditScore = creditScore,
                LoanMonthlyPayment = monthlyPayment,
                InvestmentFutureValue = futureValue
            };
        }
    }

    // DTO for returning a summary of finance information.
    public class FinanceSummary
    {
        public int CreditScore { get; set; }
        public decimal LoanMonthlyPayment { get; set; }
        public decimal InvestmentFutureValue { get; set; }
    }
}
