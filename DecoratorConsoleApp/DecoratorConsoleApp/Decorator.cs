namespace DecoratorConsoleApp
{
    public abstract class Decorator : Component
    {
        protected Component _component;

        public Decorator(Component component)
        {
            _component = component;
        }

        public override string Operation()
        {
            return _component.Operation();
        }
    }
}