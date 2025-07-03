namespace DecoratorConsoleApp
{
    // Decorator that applies a service fee to the account balance
    public class FeeDecorator : AccountDecorator
    {
        private decimal _feeAmount;

        public FeeDecorator(Account account, decimal feeAmount) : base(account)
        {
            _feeAmount = feeAmount;
        }

        public override decimal GetBalance()
        {
            // Subtracts the fee from the current balance
            return base.GetBalance() - _feeAmount;
        }
    }
}