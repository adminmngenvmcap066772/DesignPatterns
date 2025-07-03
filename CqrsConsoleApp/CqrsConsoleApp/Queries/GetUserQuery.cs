// Moved to Queries folder
namespace CqrsConsoleApp.Queries
{
    using CqrsConsoleApp.Commands;
    using CqrsConsoleApp.Entities;
    /// <summary>
    /// Query to get a user by ID.
    /// </summary>
    public class GetUserQuery : IQuery<User?>
    {
        public int Id { get; set; }
        /// <summary>
        /// Initializes a new instance of the GetUserQuery class.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        public GetUserQuery(int id) => Id = id;
    }
}
