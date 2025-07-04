// This factory creates financial products based on a string key.
namespace FactoryConsoleApp.FinancialProducts
{
    public static class FinancialProductFactory
    {
        public static IFinancialProduct CreateProduct(string productType)
        {
            // Use case-insensitive comparison for flexibility
            switch (productType.ToLower())
            {
                case "loan":
                    return new Loan();
                case "savingsaccount":
                    return new SavingsAccount();
                default:
                    throw new ArgumentException($"Unknown product type: {productType}");
            }
        }
    }
}
