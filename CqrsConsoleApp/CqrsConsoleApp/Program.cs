// See https://aka.ms/new-console-template for more information

using CqrsConsoleApp.Repositories;
using CqrsConsoleApp.CommandHandlers;
using CqrsConsoleApp.Commands;
using CqrsConsoleApp.QueryHandlers;
using CqrsConsoleApp.Queries;
using System.Threading.Tasks;

// Entry point for the CQRS demo application
// Updated to async Task Main to support async/await usage
await MainAsync();

static async Task MainAsync()
{
    Console.WriteLine("Hello, World!");

    var repository = new UserRepository();

    // Create a new user using the async command handler
    var createHandler = new CreateUserCommandHandler(repository);
    // Demonstrates async/await: simulates fetching a credit score before creating a user (finance scenario)
    var user = await createHandler.HandleAsync(new CreateUserCommand("Alice"));
    Console.WriteLine($"Created user: {user.Id} - {user.Name}");

    // Query the user by ID using the async query handler
    var queryHandler = new GetUserQueryHandler(repository);
    var queriedUser = await queryHandler.HandleAsync(new GetUserQuery(user.Id));
    Console.WriteLine(queriedUser != null
        ? $"Queried user: {queriedUser.Id} - {queriedUser.Name}"
        : "User not found");
}
