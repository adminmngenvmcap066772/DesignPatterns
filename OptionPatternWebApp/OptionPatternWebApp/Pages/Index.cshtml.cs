using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace OptionPatternWebApp.Pages
{
    // The Index page model demonstrates how to use the options pattern
    // to access configuration values, such as those used in a finance dashboard.
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyAppOptions _options;

        // Expose the configuration values to the Razor page.
        public string SiteTitle => _options.SiteTitle;
        public int MaxItems => _options.MaxItems;

        // Inject IOptions<MyAppOptions> to access configuration values.
        public IndexModel(ILogger<IndexModel> logger, IOptions<MyAppOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }

        public void OnGet()
        {
            // Example: In a finance scenario, you could use MaxItems to limit
            // the number of recent transactions shown on a dashboard.
        }
    }
}
