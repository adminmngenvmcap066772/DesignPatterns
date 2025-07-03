// See https://aka.ms/new-console-template for more information
using System;
using Polly;

Console.WriteLine("Hello, World!");
Console.WriteLine("Polly Retry Demo:");
new RetryDemo().Run();
Console.WriteLine("\nPolly Circuit Breaker Demo:");
new CircuitBreakerDemo().Run();
