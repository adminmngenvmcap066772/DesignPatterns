// This class represents a simple bank account entity for demonstration purposes.
namespace RepositoryPatternConsoleApp.Entities
{
    public class Account
    {
        public int Id { get; set; } // Unique identifier for the account
        public string Owner { get; set; } // Name of the account owner
        public decimal Balance { get; set; } // Current balance of the account
    }
}
