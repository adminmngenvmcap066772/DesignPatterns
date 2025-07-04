using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace TestingWebApp.Pages
{
    // This page demonstrates the use of AddScoped, AddSingleton, and AddTransient lifetimes in ASP.NET Core DI.
    // In a finance scenario, you might use these lifetimes for services like interest calculators, budget managers, or analytics engines.
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ScopedDemoService _scoped;
        private readonly SingletonDemoService _singleton;
        private readonly TransientDemoService _transient;
        private readonly IServiceProvider _serviceProvider;

        // Expose the operation IDs for each service lifetime to the Razor page
        public Guid ScopedId { get; private set; }
        public Guid SingletonId { get; private set; }
        public Guid TransientId { get; private set; }
        public Guid ReloadedScopedId { get; set; }
        public Guid ReloadedSingletonId { get; set; }
        public Guid ReloadedTransientId { get; set; }

        // Inject the demo services for each lifetime and IServiceProvider for manual reload
        public IndexModel(
            ILogger<IndexModel> logger,
            ScopedDemoService scoped,
            SingletonDemoService singleton,
            TransientDemoService transient,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _scoped = scoped;
            _singleton = singleton;
            _transient = transient;
            _serviceProvider = serviceProvider;
            // Store the operation IDs for each service lifetime
            ScopedId = scoped.GetOperationId();
            SingletonId = singleton.GetOperationId();
            TransientId = transient.GetOperationId();
        }

        // Handler to reload ScopedId, SingletonId, and TransientId
        public async Task<IActionResult> OnPostReloadAsync()
        {
            // Get new instances from the service provider
            var newScoped = (ScopedDemoService)_serviceProvider.GetService(typeof(ScopedDemoService));
            var newSingleton = (SingletonDemoService)_serviceProvider.GetService(typeof(SingletonDemoService));
            var newTransient = (TransientDemoService)_serviceProvider.GetService(typeof(TransientDemoService));
            ReloadedScopedId = newScoped.GetOperationId();
            ReloadedSingletonId = newSingleton.GetOperationId();
            ReloadedTransientId = newTransient.GetOperationId();
            // Keep the original values for display
            ScopedId = _scoped.GetOperationId();
            SingletonId = _singleton.GetOperationId();
            TransientId = _transient.GetOperationId();
            return Page();
        }
    }
}

