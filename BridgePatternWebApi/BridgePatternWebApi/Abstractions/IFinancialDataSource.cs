// This interface defines the implementation side of the Bridge pattern.
// It abstracts how financial data is retrieved, allowing multiple data source implementations.
namespace BridgePatternWebApi.Abstractions
{
    public interface IFinancialDataSource
    {
        // Async method signatures for retrieving financial data
        Task<decimal> GetMonthlyRevenueAsync();
        Task<decimal> GetMonthlyExpensesAsync();
    }
}
