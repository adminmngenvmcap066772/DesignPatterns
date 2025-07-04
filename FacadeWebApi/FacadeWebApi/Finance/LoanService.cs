// This class simulates a loan calculation service in a finance system.
namespace FacadeWebApi.Finance
{
    public class LoanService
    {
        // Calculates the monthly payment for a loan using the formula for an amortizing loan.
        public decimal CalculateMonthlyPayment(decimal principal, double annualRate, int years)
        {
            double monthlyRate = annualRate / 12 / 100;
            int totalPayments = years * 12;
            double denominator = Math.Pow(1 + monthlyRate, totalPayments) - 1;
            if (denominator == 0) return principal / totalPayments;
            double payment = (double)principal * monthlyRate * Math.Pow(1 + monthlyRate, totalPayments) / denominator;
            return (decimal)payment;
        }
    }
}