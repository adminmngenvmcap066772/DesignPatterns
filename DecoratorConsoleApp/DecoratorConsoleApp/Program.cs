using System;

namespace DecoratorConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Component component = new ConcreteComponent();
            Console.WriteLine("Base: " + component.Operation());

            Component decoratorA = new ConcreteDecoratorA(component);
            Console.WriteLine("DecoratorA: " + decoratorA.Operation());

            Component decoratorB = new ConcreteDecoratorB(decoratorA);
            Console.WriteLine("DecoratorB: " + decoratorB.Operation());
        }
    }
}
