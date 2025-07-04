// This class represents a Loan product.
namespace FactoryConsoleApp.FinancialProducts
{
    public class Loan : IFinancialProduct
    {
        public void Describe()
        {
            // Example: Print details about the loan
            Console.WriteLine("Loan: A financial product for borrowing money with interest.");
        }
    }
}
