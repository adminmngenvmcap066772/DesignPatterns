namespace StrategyPatternConsoleApp.Strategies
{
    // Implements compound interest calculation strategy.
    public class CompoundInterestStrategy : IInterestCalculationStrategy
    {
        public double CalculateInterest(double principal, double rate, int years)
        {
            // Compound Interest = Principal * ( (1 + Rate)^Years - 1 )
            return principal * (System.Math.Pow(1 + rate, years) - 1);
        }
    }
}
