// Moved to QueryHandlers folder

namespace CqrsConsoleApp.QueryHandlers
{
    using CqrsConsoleApp.Repositories;
    using CqrsConsoleApp.Queries;
    using CqrsConsoleApp.Entities;
    using CqrsConsoleApp.Commands;

    /// <summary>
    /// Handles the GetUserQuery to retrieve a user by ID.
    /// </summary>
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, User?>
    {
        private readonly UserRepository _repository;

        /// <summary>
        /// Initializes a new instance of the GetUserQueryHandler class.
        /// </summary>
        /// <param name="repository">The user repository.</param>
        public GetUserQueryHandler(UserRepository repository) => _repository = repository;

        /// <summary>
        /// Handles the GetUserQuery.
        /// </summary>
        /// <param name="query">The query to handle.</param>
        /// <returns>The User object if found; otherwise, null.</returns>
        public User? Handle(GetUserQuery query)
        {
            // Validate the query
            if (query.Id <= 0)
            {
                throw new ArgumentException("User ID must be greater than zero.");
            }

            // Retrieve the user from the repository
            var user = _repository.GetById(query.Id);

            // Additional logic: check if the user's name is empty or null
            if (user != null && string.IsNullOrWhiteSpace(user.Name))
            {
                // Assign a default name if missing
                user.Name = $"User_{user.Id}";
            }

            // Additional logic: log if user is not found
            if (user == null)
            {
                System.Console.WriteLine($"[WARN] User with Id={query.Id} not found.");
            }

            // Additional logic: simulate access control (e.g., block access to user with Id 999)
            if (user != null && user.Id == 999)
            {
                throw new UnauthorizedAccessException("Access to this user is restricted.");
            }

            return user;
        }
    }
}
