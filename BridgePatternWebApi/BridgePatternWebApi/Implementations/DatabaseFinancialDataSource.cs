using BridgePatternWebApi.Abstractions;

// This class simulates retrieving financial data from a database.
// It implements the IFinancialDataSource interface.
namespace BridgePatternWebApi.Implementations
{
    public class DatabaseFinancialDataSource : IFinancialDataSource
    {
        public decimal GetMonthlyRevenue()
        {
            // Simulate database access
            return 10000m; // Example revenue
        }

        public decimal GetMonthlyExpenses()
        {
            // Simulate database access
            return 7000m; // Example expenses
        }

        public async Task<decimal> GetMonthlyRevenueAsync()
        {
            // Simulate async database access
            await Task.Delay(50); // Simulate latency
            return 10000m; // Example revenue
        }

        public async Task<decimal> GetMonthlyExpensesAsync()
        {
            // Simulate async database access
            await Task.Delay(50); // Simulate latency
            return 7000m; // Example expenses
        }
    }
}
