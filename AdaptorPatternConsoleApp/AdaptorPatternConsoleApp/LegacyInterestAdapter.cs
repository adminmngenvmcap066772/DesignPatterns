// Adapter class to make LegacyInterestService compatible with IInterestCalculator.
public class LegacyInterestAdapter : IInterestCalculator
{
    private readonly LegacyInterestService _legacyService;

    public LegacyInterestAdapter(LegacyInterestService legacyService)
    {
        _legacyService = legacyService;
    }

    // Adapts the method signature to match IInterestCalculator.
    public decimal CalculateInterest(decimal principal, decimal rate, int years)
    {
        // Delegates the call to the legacy service.
        return _legacyService.GetSimpleInterestAmount(principal, rate, years);
    }
}
