// Moved to Repositories folder

namespace CqrsConsoleApp.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using CqrsConsoleApp.Entities;
    /// <summary>
    /// Provides in-memory storage and management for User entities.
    /// Repository pattern is used to encapsulate data access logic.
    /// </summary>
    public class UserRepository
    {
        private readonly List<User> _users = new();
        private int _nextId = 1;

        /// <summary>
        /// Adds a new user with the specified name.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <returns>The created User object.</returns>
        public User Add(string name)
        {
            var user = new User { Id = _nextId++, Name = name };
            _users.Add(user);
            return user;
        }

        /// <summary>
        /// Gets a user by their unique identifier.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns>The User object if found; otherwise, null.</returns>
        public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);
    }
}
