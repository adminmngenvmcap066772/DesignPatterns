// The SavingsAccount class is another concrete implementation of Account.
// It can participate in interactions coordinated by the mediator, such as receiving transfers.
// This class can be extended with additional financial logic (e.g., interest calculation).
using MediatorWebApi.MediatorPattern.Accounts;

namespace MediatorWebApi.MediatorPattern.Accounts
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string accountName, decimal initialBalance, IMediator mediator)
            : base(accountName, initialBalance, mediator) { }
        // Additional savings-specific logic could be added here
    }
}
