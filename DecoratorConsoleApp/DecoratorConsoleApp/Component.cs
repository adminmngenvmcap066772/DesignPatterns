namespace DecoratorConsoleApp
{
    // Abstract base class representing a financial account
    // Defines the contract for calculating the account balance
    public abstract class Account
    {
        public abstract decimal GetBalance();
    }
}