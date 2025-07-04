// This console app demonstrates calling the Mediator Web API endpoints for financial scenarios.
// It uses HttpClient to interact with the AccountTransfer and LoanApproval controllers.
// Make sure the MediatorWebApi project is running before executing this console app.

using System.Net.Http;
using System.Threading.Tasks;

// Entry point for the console app
class Program
{
    static async Task Main(string[] args)
    {
        // Base address for the local Web API (adjust port if needed)
        var baseAddress = "http://localhost:5260";
        using var client = new HttpClient { BaseAddress = new Uri(baseAddress) };

        // --- Account Transfer Example ---
        Console.WriteLine("Calling AccountTransfer API to transfer $100 from Checking to Savings...");
        var transferResponse = await client.PostAsync($"/AccountTransfer/transfer?amount=100", null);
        var transferResult = await transferResponse.Content.ReadAsStringAsync();
        Console.WriteLine("Account Transfer Result:");
        Console.WriteLine(transferResult);

        // --- Loan Approval Example ---
        Console.WriteLine("\nCalling LoanApproval API to review a $5000 loan for Alice...");
        var loanResponse = await client.PostAsync($"/LoanApproval/review?applicant=Alice&amount=5000", null);
        var loanResult = await loanResponse.Content.ReadAsStringAsync();
        Console.WriteLine("Loan Approval Result:");
        Console.WriteLine(loanResult);

        // Prevent the console from exiting immediately
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}
