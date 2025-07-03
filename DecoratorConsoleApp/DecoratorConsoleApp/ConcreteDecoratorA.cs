namespace DecoratorConsoleApp
{
    // Decorator that adds interest to the account balance
    public class InterestDecorator : AccountDecorator
    {
        private decimal _interestRate; // e.g., 0.05 for 5%

        public InterestDecorator(Account account, decimal interestRate) : base(account)
        {
            _interestRate = interestRate;
        }

        public override decimal GetBalance()
        {
            // Adds interest to the current balance
            return base.GetBalance() * (1 + _interestRate);
        }
    }
}