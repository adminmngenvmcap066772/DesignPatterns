using System;

public class UnreliableService
{
    private int _failuresLeft;
    public UnreliableService(int failures)
    {
        _failuresLeft = failures;
    }
    public void DoWork()
    {
        if (_failuresLeft-- > 0)
            throw new Exception("Transient failure");
        Console.WriteLine("Work succeeded!");
    }
}