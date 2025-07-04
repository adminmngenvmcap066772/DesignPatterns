// This is a legacy class with a different interface for interest calculation.
public class LegacyInterestService
{
    // Calculates simple interest, but uses a different method signature.
    public decimal GetSimpleInterestAmount(decimal amount, decimal annualRate, int periodInYears)
    {
        // Simple interest formula: Principal * Rate * Time
        return amount * annualRate * periodInYears;
    }
}
