using System;

// This program demonstrates the Adapter Pattern in a finance scenario.
// The Adapter Pattern is used here to allow the new system (which expects the IInterestCalculator interface)
// to work with a legacy interest calculation service (LegacyInterestService) that has a different interface.
// This approach enables integration of old code without modifying it, promoting code reuse and flexibility.
// In financial applications, this is especially useful when migrating or extending systems with existing logic.
class Program
{
    static void Main(string[] args)
    {
        // Example: Calculate interest using the Adapter Pattern in a finance scenario.
        decimal principal = 10000m; // Principal amount
        decimal rate = 0.05m;       // 5% annual interest rate
        int years = 3;              // Investment period in years

        // Create the legacy service and adapter
        // The adapter allows the legacy service to be used where IInterestCalculator is expected
        var legacyService = new LegacyInterestService();
        IInterestCalculator calculator = new LegacyInterestAdapter(legacyService);

        // Calculate interest using the adapter
        decimal interest = calculator.CalculateInterest(principal, rate, years);

        Console.WriteLine($"Interest for principal ${principal} at {rate:P} for {years} years: ${interest}");
    }
}
