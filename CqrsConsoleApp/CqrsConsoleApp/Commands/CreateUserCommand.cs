namespace CqrsConsoleApp.Commands
{
    using CqrsConsoleApp.Entities;

    /// <summary>
    /// Command to create a new user.
    /// </summary>
    public class CreateUserCommand : ICommand<User>
    {
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the CreateUserCommand class.
        /// </summary>
        /// <param name="name">The name of the user to create.</param>
        public CreateUserCommand(string name) => Name = name;
    }
}
