// Moved to CommandHandlers folder

namespace CqrsConsoleApp.CommandHandlers
{
    using CqrsConsoleApp.Repositories;
    using CqrsConsoleApp.Commands;
    using CqrsConsoleApp.Entities;
    using CqrsConsoleApp.Interface;
    using System.Threading.Tasks;

    /// <summary>
    /// Handles the CreateUserCommand to add a new user.
    /// </summary>
    public class CreateUserCommandHandler
    {
        private readonly UserRepository _repository;

        /// <summary>
        /// Initializes a new instance of the CreateUserCommandHandler class.
        /// </summary>
        /// <param name="repository">The user repository.</param>
        public CreateUserCommandHandler(UserRepository repository) => _repository = repository;

        /// <summary>
        /// Handles the CreateUserCommand asynchronously.
        /// </summary>
        /// <param name="command">The command to handle.</param>
        /// <returns>The created User object.</returns>
        public async Task<User> HandleAsync(CreateUserCommand command)
        {
            // Fake logic: simulate input validation
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                System.Console.WriteLine("[ERROR] User name cannot be empty. Assigning default name.");
                command.Name = $"User_{System.Guid.NewGuid()}";
            }

            // Use Task.Delay instead of Thread.Sleep to simulate async database latency
            await Task.Delay(150); // Simulate latency

            // Simulate fetching a credit score asynchronously (e.g., from a financial API)
            int creditScore = await FetchCreditScoreAsync(command.Name);
            System.Console.WriteLine($"[INFO] Fetched credit score for {command.Name}: {creditScore}");

            // Fake logic: log the command (in real code, use a logger)
            System.Console.WriteLine($"[LOG] Creating user with name: {command.Name}");

            // Fake logic: simulate a business rule (e.g., block certain names)
            if (command.Name.ToLower().Contains("admin"))
            {
                System.Console.WriteLine("[WARN] Cannot create user with reserved name 'admin'.");
                return new User { Id = -1, Name = "Invalid User" };
            }

            // Real logic: add user to repository
            var user = _repository.Add(command.Name);

            // Fake logic: simulate post-processing (e.g., send welcome email)
            System.Console.WriteLine($"[INFO] Welcome email sent to {user.Name}@example.com");

            return user;
        }

        /// <summary>
        /// Simulates an asynchronous call to fetch a user's credit score.
        /// In a real finance app, this would call an external API.
        /// </summary>
        /// <param name="userName">The user's name.</param>
        /// <returns>A simulated credit score.</returns>
        private async Task<int> FetchCreditScoreAsync(string userName)
        {
            // Simulate network latency
            await Task.Delay(100);
            // Return a random credit score for demonstration
            return new System.Random().Next(300, 850);
        }
    }
}
