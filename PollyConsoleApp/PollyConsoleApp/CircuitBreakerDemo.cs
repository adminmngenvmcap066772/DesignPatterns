using System;
using Polly;

public class CircuitBreakerDemo
{
    public void Run()
    {
        var service = new UnreliableService(2);
        var circuitBreaker = Policy
            .Handle<Exception>()
            .CircuitBreaker(2, TimeSpan.FromSeconds(5));
        for (int i = 0; i < 5; i++)
        {
            try
            {
                circuitBreaker.Execute(() => service.DoWork());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Attempt {i + 1}: {ex.Message}");
            }
        }
    }
}