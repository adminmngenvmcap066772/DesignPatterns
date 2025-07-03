namespace UnitTestingConsoleApp
{
    // Implementation of ILogger
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
