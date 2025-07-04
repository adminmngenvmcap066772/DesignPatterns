// This interface defines the abstraction for generating a financial report.
// It uses the Bridge pattern to decouple the report logic from the data source implementation.
namespace BridgePatternWebApi.Abstractions
{
    public interface IFinancialReport
    {
        // Async method signature for generating a report
        Task<string> GenerateReportAsync();
    }
}
