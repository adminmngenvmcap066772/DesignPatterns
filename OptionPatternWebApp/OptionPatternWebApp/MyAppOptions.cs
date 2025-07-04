// This class represents configuration options for the application.
// In a financial context, these could be used to control features like interest rate calculations or budget limits.
namespace OptionPatternWebApp
{
    public class MyAppOptions
    {
        // The title of the site, which could be set to something like "Finance Dashboard".
        public string SiteTitle { get; set; } = string.Empty;
        // The maximum number of items to display, e.g., max transactions or budget categories.
        public int MaxItems { get; set; }
    }
}
