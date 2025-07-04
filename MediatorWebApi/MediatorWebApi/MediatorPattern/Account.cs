// The abstract Account class represents a financial account (e.g., checking or savings).
// Each Account holds a reference to the mediator, allowing it to communicate indirectly with other accounts.
// This design supports the Mediator pattern by ensuring accounts do not reference each other directly.
namespace MediatorWebApi.MediatorPattern
{
    public abstract class Account
    {
        // Reference to the mediator for coordinating actions between accounts
        protected IMediator _mediator;
        // Name of the account (for identification)
        public string AccountName { get; }
        // Current balance of the account
        public decimal Balance { get; protected set; }

        // Constructor sets up the account and assigns the mediator
        public Account(string accountName, decimal initialBalance, IMediator mediator)
        {
            AccountName = accountName;
            Balance = initialBalance;
            _mediator = mediator;
        }

        // Deposit funds into the account
        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }

        // Withdraw funds from the account if sufficient balance exists
        public virtual void Withdraw(decimal amount)
        {
            if (Balance >= amount)
                Balance -= amount;
        }
    }
}
