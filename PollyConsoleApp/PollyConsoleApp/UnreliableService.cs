using System;

// This class simulates a financial service that may fail a few times before succeeding.
// In a real-world finance scenario, this could represent a service that fetches interest rates from an external provider,
// which may be temporarily unavailable due to network issues or provider downtime.
public class UnreliableService
{
    private int _failuresLeft;

    // Constructor accepts the number of times the service should fail before succeeding.
    public UnreliableService(int failures)
    {
        _failuresLeft = failures;
    }

    // Simulates a call to an external financial service, such as fetching the latest interest rate.
    // Throws an exception if the service is set to fail, otherwise prints a success message.
    public void DoWork()
    {
        if (_failuresLeft-- > 0)
            throw new Exception("Transient failure: Unable to fetch interest rate from provider.");
        Console.WriteLine("Interest rate fetched successfully!");
    }
}