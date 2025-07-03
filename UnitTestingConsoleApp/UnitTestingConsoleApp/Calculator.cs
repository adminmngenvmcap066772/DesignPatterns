namespace UnitTestingConsoleApp
{
    // Implementation of ICalculator
    public class Calculator : ICalculator
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
    }
}
