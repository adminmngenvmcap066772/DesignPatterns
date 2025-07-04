using System;
using System.Threading.Tasks;
using RepositoryPatternConsoleApp.Entities;
using RepositoryPatternConsoleApp.Repositories;

/*
 * When NOT to Use the Repository Pattern:
 * ----------------------------------------
 * 1. Simple or Small Applications:
 *    - If your application is small, with minimal data access logic, adding a repository layer can introduce unnecessary complexity and boilerplate code.
 *
 * 2. Direct Use of ORMs with Rich Features:
 *    - Modern ORMs (like Entity Framework Core) already provide abstraction, querying, and unit of work patterns. Wrapping them with repositories can lead to redundant code and limit access to advanced ORM features.
 *
 * 3. Read-Heavy, Complex Queries (CQRS):
 *    - For applications using CQRS (Command Query Responsibility Segregation), repositories may not fit well for complex read operations, as queries often require custom projections or joins that don’t map cleanly to entity repositories.
 *
 * 4. Rapid Prototyping or Throwaway Code:
 *    - When building quick prototypes or proof-of-concept projects, the overhead of designing repositories is usually not justified.
 *
 * 5. Microservices with Simple Data Access:
 *    - In microservices where each service owns its data and has simple CRUD operations, direct use of the ORM or data access code may be more efficient.
 *
 * Summary:
 * Avoid the repository pattern when it adds unnecessary abstraction, duplicates ORM functionality, or complicates simple data access needs. Use it when you need clear separation, testability, and flexibility in data access logic.
 */

// Demonstrates the repository pattern in a financial context (managing bank accounts) with async methods
class Program
{
    static async Task Main()
    {
        IAccountRepository accountRepo = new AccountRepository();

        // Add new accounts asynchronously
        await accountRepo.AddAsync(new Account { Id = 1, Owner = "Alice", Balance = 1000m });
        await accountRepo.AddAsync(new Account { Id = 2, Owner = "Bob", Balance = 2500m });

        // Retrieve and display all accounts asynchronously
        Console.WriteLine("All Accounts:");
        var allAccounts = await accountRepo.GetAllAsync();
        foreach (var acc in allAccounts)
            Console.WriteLine($"Id: {acc.Id}, Owner: {acc.Owner}, Balance: {acc.Balance:C}");

        // Update an account (e.g., deposit) asynchronously
        var alice = await accountRepo.GetByIdAsync(1);
        alice.Balance += 500m; // Alice deposits $500
        await accountRepo.UpdateAsync(alice);

        // Display updated account
        Console.WriteLine("\nAfter deposit:");
        var updatedAlice = await accountRepo.GetByIdAsync(1);
        Console.WriteLine($"Id: {updatedAlice.Id}, Owner: {updatedAlice.Owner}, Balance: {updatedAlice.Balance:C}");

        // Delete an account asynchronously
        await accountRepo.DeleteAsync(2);
        Console.WriteLine("\nAfter deleting Bob's account:");
        allAccounts = await accountRepo.GetAllAsync();
        foreach (var acc in allAccounts)
            Console.WriteLine($"Id: {acc.Id}, Owner: {acc.Owner}, Balance: {acc.Balance:C}");
    }
}
