namespace DecoratorConsoleApp
{
    // Concrete implementation of a basic bank account
    // Stores the initial balance and returns it
    public class BasicAccount : Account
    {
        private decimal _initialBalance;

        public BasicAccount(decimal initialBalance)
        {
            _initialBalance = initialBalance;
        }

        public override decimal GetBalance()
        {
            return _initialBalance;
        }
    }
}