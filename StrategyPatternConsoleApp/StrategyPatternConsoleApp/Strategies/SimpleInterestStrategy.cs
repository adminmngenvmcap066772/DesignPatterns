namespace StrategyPatternConsoleApp.Strategies
{
    // Implements simple interest calculation strategy.
    public class SimpleInterestStrategy : IInterestCalculationStrategy
    {
        public double CalculateInterest(double principal, double rate, int years)
        {
            // Simple Interest = Principal * Rate * Time
            return principal * rate * years;
        }
    }
}
