using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Demo: Async and Await Scenarios\n");

        // 1. Simple async method returning Task
        // Demonstrates awaiting a method that performs an asynchronous operation without returning a value.
        await SimpleAsync();

        // 2. Async method returning Task<T>
        // Demonstrates awaiting a method that returns a computed result asynchronously.
        int result = await CalculateSumAsync(5, 7);
        Console.WriteLine($"Sum result: {result}");

        // 3. Async method with exception handling
        // Demonstrates catching exceptions thrown from an awaited async method.
        try
        {
            await ThrowingAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught exception: {ex.Message}");
        }

        // 4. Parallel async operations with Task.WhenAll
        // Demonstrates running multiple async operations in parallel and awaiting their completion.
        var tasks = new[] { DelayAndReturnAsync(1), DelayAndReturnAsync(2), DelayAndReturnAsync(3) };
        int[] results = await Task.WhenAll(tasks);
        Console.WriteLine($"Parallel results: {string.Join(", ", results)}");

        // 5. Chaining async methods
        // Demonstrates awaiting one async method inside another for sequential async operations.
        int chainedResult = await FirstAsync();
        Console.WriteLine($"Chained result: {chainedResult}");
    }

    // Simple async method that completes after a delay
    static async Task SimpleAsync()
    {
        await Task.Delay(500); // Simulate asynchronous work
        Console.WriteLine("SimpleAsync completed.");
    }

    // Async method that returns a computed sum after a delay
    static async Task<int> CalculateSumAsync(int a, int b)
    {
        await Task.Delay(300); // Simulate asynchronous work
        return a + b;
    }

    // Async method that throws an exception after a delay
    static async Task ThrowingAsync()
    {
        await Task.Delay(200); // Simulate asynchronous work
        throw new InvalidOperationException("Demo exception from async method.");
    }

    // Async method that returns a value after a delay, used for parallel execution
    static async Task<int> DelayAndReturnAsync(int value)
    {
        await Task.Delay(value * 200); // Simulate asynchronous work
        return value * 10;
    }

    // Async method that chains another async method
    static async Task<int> FirstAsync()
    {
        int intermediate = await SecondAsync(); // Await another async method
        return intermediate * 2;
    }

    // Async method used in chaining example
    static async Task<int> SecondAsync()
    {
        await Task.Delay(100); // Simulate asynchronous work
        return 21;
    }
}
