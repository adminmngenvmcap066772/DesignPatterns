// The IMediator interface defines a contract for communication between Account objects (colleagues).
// By using this interface, Account objects do not communicate with each other directly.
// Instead, they send messages to the mediator, which coordinates the interaction.
// This decouples the colleagues and centralizes the communication logic.
namespace MediatorWebApi.MediatorPattern
{
    public interface IMediator
    {
        // Notify is called by an Account to inform the mediator of an action (e.g., transfer, deposit, withdraw).
        // The mediator can then coordinate the response or trigger additional logic.
        void Notify(Account sender, string action, decimal amount);
    }
}
