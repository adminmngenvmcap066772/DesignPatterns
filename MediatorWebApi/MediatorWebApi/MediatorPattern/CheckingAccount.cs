// The CheckingAccount class is a concrete implementation of Account.
// It demonstrates how an account can use the mediator to coordinate actions (like transfers) with other accounts.
// The account does not need to know the details of the target account, only that it can interact via the mediator.
namespace MediatorWebApi.MediatorPattern
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(string accountName, decimal initialBalance, IMediator mediator)
            : base(accountName, initialBalance, mediator) { }

        // Transfer funds from this account to another account using the mediator.
        // The mediator is notified of the transfer, which could trigger additional logic (e.g., logging, validation).
        public void TransferTo(Account target, decimal amount)
        {
            if (Balance >= amount)
            {
                // Notify the mediator that a transfer is occurring
                _mediator.Notify(this, "Transfer", amount);
                // Deposit the amount into the target account
                target.Deposit(amount);
                // Withdraw the amount from this account
                this.Withdraw(amount);
            }
        }
    }
}
