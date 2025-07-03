using System;
using Polly;

public class RetryDemo
{
    public void Run()
    {
        var service = new UnreliableService(2);
        var retry = Policy
            .Handle<Exception>()
            .Retry(3, (exception, retryCount) =>
            {
                Console.WriteLine($"Retry {retryCount} due to: {exception.Message}");
            });
        retry.Execute(() => service.DoWork());
    }
}