// Moved to Interfaces folder


// Moved to Interfaces folder

namespace CqrsConsoleApp.Commands
{
    /// <summary>
    /// Handles a query of type TQuery and returns a response of type TResponse.
    /// </summary>
    public interface IQueryHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {
        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query">The query to handle.</param>
        /// <returns>The response from handling the query.</returns>
        TResponse Handle(TQuery query);
    }
}
