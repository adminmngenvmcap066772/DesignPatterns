// The AccountMediator class is the concrete mediator that coordinates communication between Account objects.
// It implements the IMediator interface and centralizes the logic for handling actions between accounts.
// This allows for easy extension (e.g., adding logging, validation, or notifications) without modifying the account classes.
namespace MediatorWebApi.MediatorPattern
{
    public class AccountMediator : IMediator
    {
        // The Notify method is called by accounts to inform the mediator of an action.
        // The mediator can then perform additional logic, such as logging or enforcing business rules.
        public void Notify(Account sender, string action, decimal amount)
        {
            // Example: Log the action to the console (could be replaced with real logging or notifications)
            System.Console.WriteLine($"{sender.AccountName} performed {action} of {amount:C}.");
        }
    }
}
