using System.Net.Http.Json;
using System.Text.Json;

// This console app demonstrates how to submit loan applications to the LoanApplicationWebApi.
// It shows two use cases: one that passes validation and one that fails validation.

// Define the LoanApplication model matching the API contract
public class LoanApplication
{
    public string ApplicantName { get; set; } = string.Empty;
    public decimal LoanAmount { get; set; }
    public decimal InterestRate { get; set; }
    public int TermYears { get; set; }
}

// Entry point of the console application
class Program
{
    static async Task Main(string[] args)
    {
        // Use case 1: Valid loan application (should pass validation)
        var validApplication = new LoanApplication
        {
            ApplicantName = "Alice Smith",
            LoanAmount = 10000m, // $10,000 loan
            InterestRate = 5.5m, // 5.5% annual interest
            TermYears = 5        // 5-year term
        };

        // Use case 2: Invalid loan application (should fail validation)
        var invalidApplication = new LoanApplication
        {
            ApplicantName = "",         // Invalid: empty name
            LoanAmount = -5000m,         // Invalid: negative loan amount
            InterestRate = 150m,         // Invalid: interest rate out of range
            TermYears = 0                // Invalid: term less than 1 year
        };

        // Set the API endpoint URL (adjust port if needed)
        var apiUrl = "http://localhost:5145/LoanApplication";

        using var httpClient = new HttpClient();

        // Helper method to send and display results for each use case
        async Task SubmitAndDisplayResult(LoanApplication application, string caseDescription)
        {
            Console.WriteLine($"\n--- {caseDescription} ---");
            try
            {
                // Send the loan application as JSON to the API
                var response = await httpClient.PostAsJsonAsync(apiUrl, application);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    // Display the result, which includes the calculated total interest
                    Console.WriteLine("Loan application submitted successfully.");
                    Console.WriteLine("API Response: " + responseContent);
                }
                else
                {
                    // Display validation errors or other issues
                    Console.WriteLine($"API Error ({response.StatusCode}): {responseContent}");
                }
            }
            catch (Exception ex)
            {
                // Handle network or serialization errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Run both use cases
        await SubmitAndDisplayResult(validApplication, "Use Case 1: Valid Application (Should Pass Validation)");
        await SubmitAndDisplayResult(invalidApplication, "Use Case 2: Invalid Application (Should Fail Validation)");

        // Keep the console window open so the user can review the output
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}
