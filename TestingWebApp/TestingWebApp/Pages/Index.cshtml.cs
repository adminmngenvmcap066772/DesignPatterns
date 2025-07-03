using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestingWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public Guid ScopedId { get; }
        public Guid SingletonId { get; }
        public Guid TransientId { get; }

        public IndexModel(ILogger<IndexModel> logger,
            ScopedDemoService scoped,
            SingletonDemoService singleton,
            TransientDemoService transient)
        {
            _logger = logger;
            ScopedId = scoped.GetOperationId();
            SingletonId = singleton.GetOperationId();
            TransientId = transient.GetOperationId();
        }

        public void OnGet()
        {
        }
    }
}
