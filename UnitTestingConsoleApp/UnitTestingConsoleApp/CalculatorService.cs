namespace UnitTestingConsoleApp
{
    // A service that uses both ICalculator and ILogger
    public class CalculatorService
    {
        private readonly ICalculator _calculator;
        private readonly ILogger _logger;

        public CalculatorService(ICalculator calculator, ILogger logger)
        {
            _calculator = calculator;
            _logger = logger;
        }

        public int AddAndLog(int a, int b)
        {
            int result = _calculator.Add(a, b);
            _logger.Log($"Add: {a} + {b} = {result}");
            return result;
        }
    }
}
