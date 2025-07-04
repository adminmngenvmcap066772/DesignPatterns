// The ILoanMediator interface defines the contract for communication between loan officers.
// It allows loan officers to notify the mediator of their decision, and the mediator coordinates the overall approval process.
namespace MediatorWebApi.MediatorPattern
{
    public interface ILoanMediator
    {
        void NotifyDecision(LoanOfficer sender, LoanApplication application, bool approved);
    }
}
