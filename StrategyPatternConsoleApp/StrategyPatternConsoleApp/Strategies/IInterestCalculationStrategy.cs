namespace StrategyPatternConsoleApp.Strategies
{
    // The strategy interface defines a method for calculating interest.
    public interface IInterestCalculationStrategy
    {
        // Calculates interest based on principal, rate, and time (years).
        double CalculateInterest(double principal, double rate, int years);
    }
}
