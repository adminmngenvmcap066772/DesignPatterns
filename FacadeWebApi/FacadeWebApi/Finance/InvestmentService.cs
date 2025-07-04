// This class simulates an investment calculation service in a finance system.
namespace FacadeWebApi.Finance
{
    public class InvestmentService
    {
        // Calculates the future value of an investment using compound interest.
        public decimal CalculateFutureValue(decimal initialAmount, double annualRate, int years)
        {
            double futureValue = (double)initialAmount * Math.Pow(1 + annualRate / 100, years);
            return (decimal)futureValue;
        }
    }
}