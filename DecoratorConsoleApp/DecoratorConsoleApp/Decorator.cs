namespace DecoratorConsoleApp
{
    // Abstract decorator class for Account
    // Allows additional financial operations to be added dynamically
    public abstract class AccountDecorator : Account
    {
        protected Account _account;

        public AccountDecorator(Account account)
        {
            _account = account;
        }

        public override decimal GetBalance()
        {
            return _account.GetBalance();
        }
    }
}