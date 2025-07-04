// This class represents a Savings Account product.
namespace FactoryConsoleApp.FinancialProducts
{
    public class SavingsAccount : IFinancialProduct
    {
        public void Describe()
        {
            // Example: Print details about the savings account
            Console.WriteLine("SavingsAccount: A financial product for saving money and earning interest.");
        }
    }
}
