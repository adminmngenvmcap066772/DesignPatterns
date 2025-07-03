using System;

namespace DecoratorConsoleApp
{
    // Demo program showing how to use the Decorator pattern in a financial context
    // Calculates the final account balance after applying interest and fees
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a basic account with an initial balance of $1,000
            Account account = new BasicAccount(1000m);
            Console.WriteLine($"Initial Balance: ${account.GetBalance():F2}");

            // Apply 5% interest to the account
            account = new InterestDecorator(account, 0.05m);
            Console.WriteLine($"After 5% Interest: ${account.GetBalance():F2}");

            // Apply a $20 service fee
            account = new FeeDecorator(account, 20m);
            Console.WriteLine($"After $20 Fee: ${account.GetBalance():F2}");
        }
    }
}
