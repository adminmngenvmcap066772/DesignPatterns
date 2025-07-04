// This interface defines a standard way to calculate interest in a financial system.
public interface IInterestCalculator
{
    // Calculates interest based on principal, rate, and time (in years).
    decimal CalculateInterest(decimal principal, decimal rate, int years);
}
