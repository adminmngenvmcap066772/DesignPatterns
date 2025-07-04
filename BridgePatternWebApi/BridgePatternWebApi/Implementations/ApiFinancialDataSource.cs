using BridgePatternWebApi.Abstractions;

// This class simulates retrieving financial data from an external API.
// It implements the IFinancialDataSource interface.
namespace BridgePatternWebApi.Implementations
{
    public class ApiFinancialDataSource : IFinancialDataSource
    {
        public decimal GetMonthlyRevenue()
        {
            // Simulate API call
            return 12000m; // Example revenue from API
        }

        public decimal GetMonthlyExpenses()
        {
            // Simulate API call
            return 8000m; // Example expenses from API
        }

        public async Task<decimal> GetMonthlyRevenueAsync()
        {
            // Simulate async API call
            await Task.Delay(50); // Simulate latency
            return 12000m; // Example revenue from API
        }

        public async Task<decimal> GetMonthlyExpensesAsync()
        {
            // Simulate async API call
            await Task.Delay(50); // Simulate latency
            return 8000m; // Example expenses from API
        }
    }
}
