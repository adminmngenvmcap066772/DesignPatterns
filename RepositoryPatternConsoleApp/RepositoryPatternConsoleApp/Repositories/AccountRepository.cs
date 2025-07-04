using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryPatternConsoleApp.Entities;

// In-memory implementation of the IAccountRepository interface with async methods.
namespace RepositoryPatternConsoleApp.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts = new(); // In-memory storage for accounts

        public Task<Account> GetByIdAsync(int id)
        {
            return Task.FromResult(_accounts.FirstOrDefault(a => a.Id == id));
        }

        public Task<IEnumerable<Account>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Account>>(_accounts);
        }

        public Task AddAsync(Account account)
        {
            _accounts.Add(account);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Account account)
        {
            var existing = _accounts.FirstOrDefault(a => a.Id == account.Id);
            if (existing != null)
            {
                existing.Owner = account.Owner;
                existing.Balance = account.Balance;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account != null)
                _accounts.Remove(account);
            return Task.CompletedTask;
        }
    }
}
