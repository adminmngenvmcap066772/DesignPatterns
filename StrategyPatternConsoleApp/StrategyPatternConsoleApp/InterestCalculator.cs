using StrategyPatternConsoleApp.Strategies;

namespace StrategyPatternConsoleApp
{
    // The context class uses a strategy to calculate interest.
    public class InterestCalculator
    {
        private IInterestCalculationStrategy _strategy;

        // Constructor accepts a strategy implementation.
        public InterestCalculator(IInterestCalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        // Calculates interest using the selected strategy.
        public double Calculate(double principal, double rate, int years)
        {
            return _strategy.CalculateInterest(principal, rate, years);
        }
    }
}
