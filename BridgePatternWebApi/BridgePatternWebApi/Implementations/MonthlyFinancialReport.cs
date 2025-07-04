using BridgePatternWebApi.Abstractions;

// This class represents a concrete financial report (monthly report).
// It uses the Bridge pattern to work with any IFinancialDataSource implementation.
namespace BridgePatternWebApi.Implementations
{
    public class MonthlyFinancialReport : IFinancialReport
    {
        private readonly IFinancialDataSource _dataSource;

        public MonthlyFinancialReport(IFinancialDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<string> GenerateReportAsync()
        {
            // Await async data source methods
            var revenue = await _dataSource.GetMonthlyRevenueAsync();
            var expenses = await _dataSource.GetMonthlyExpensesAsync();
            var profit = revenue - expenses;
            return $"Monthly Report: Revenue = {revenue:C}, Expenses = {expenses:C}, Profit = {profit:C}";
        }
    }
}
