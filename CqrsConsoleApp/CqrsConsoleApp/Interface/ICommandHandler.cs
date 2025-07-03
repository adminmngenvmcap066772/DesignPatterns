using CqrsConsoleApp.Commands;

namespace CqrsConsoleApp.Interface
{
    /// <summary>
    /// Handles a command of type TCommand and returns a response of type TResponse.
    /// </summary>
    public interface ICommandHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {
        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command to handle.</param>
        /// <returns>The response from handling the command.</returns>
        TResponse Handle(TCommand command);
    }
}
