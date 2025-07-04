using Microsoft.AspNetCore.Mvc;
using BridgePatternWebApi.Abstractions;
using BridgePatternWebApi.Implementations;
using System.Threading.Tasks;

namespace BridgePatternWebApi.Controllers
{
    // This controller demonstrates the Bridge pattern in a financial context.
    // It uses dependency injection to decouple the report logic from the data source implementation.
    [ApiController]
    [Route("[controller]")]
    public class FinancialReportController : ControllerBase
    {
        private readonly IFinancialReport _report;

        public FinancialReportController(IFinancialReport report)
        {
            _report = report;
        }

        // GET /FinancialReport
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Generates a monthly financial report using the injected data source.
            var report = await _report.GenerateReportAsync();
            return Ok(report);
        }
    }
}
