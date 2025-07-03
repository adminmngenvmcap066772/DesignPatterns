// Moved to CommandHandlers folder

namespace CqrsConsoleApp.CommandHandlers
{
    using CqrsConsoleApp.Repositories;
    using CqrsConsoleApp.Commands;
    using CqrsConsoleApp.Entities;
    using CqrsConsoleApp.Interface;

    /// <summary>
    /// Handles the CreateUserCommand to add a new user.
    /// </summary>
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, User>
    {
        private readonly UserRepository _repository;

        /// <summary>
        /// Initializes a new instance of the CreateUserCommandHandler class.
        /// </summary>
        /// <param name="repository">The user repository.</param>
        public CreateUserCommandHandler(UserRepository repository) => _repository = repository;

        /// <summary>
        /// Handles the CreateUserCommand.
        /// </summary>
        /// <param name="command">The command to handle.</param>
        /// <returns>The created User object.</returns>
        public User Handle(CreateUserCommand command)
        {
            // Fake logic: simulate input validation
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                System.Console.WriteLine("[ERROR] User name cannot be empty. Assigning default name.");
                command.Name = $"User_{System.Guid.NewGuid()}";
            }

            // Fake logic: simulate a delay as if writing to a database
            System.Threading.Thread.Sleep(150); // Simulate latency

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
    }
}
