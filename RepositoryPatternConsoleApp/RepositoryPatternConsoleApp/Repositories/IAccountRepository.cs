using System.Collections.Generic;
using System.Threading.Tasks;
using RepositoryPatternConsoleApp.Entities;

// Interface defining repository operations for Account entities.
namespace RepositoryPatternConsoleApp.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(int id); // Retrieve an account by its ID asynchronously
        Task<IEnumerable<Account>> GetAllAsync(); // Retrieve all accounts asynchronously
        Task AddAsync(Account account); // Add a new account asynchronously
        Task UpdateAsync(Account account); // Update an existing account asynchronously
        Task DeleteAsync(int id); // Delete an account by its ID asynchronously
    }
}
