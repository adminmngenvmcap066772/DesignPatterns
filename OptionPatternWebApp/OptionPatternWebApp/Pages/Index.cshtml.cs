using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace OptionPatternWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyAppOptions _options;

        public string SiteTitle => _options.SiteTitle;
        public int MaxItems => _options.MaxItems;

        public IndexModel(ILogger<IndexModel> logger, IOptions<MyAppOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }

        public void OnGet()
        {
        }
    }
}
