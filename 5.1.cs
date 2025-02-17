using System;

class Program
{
    public static int FibonacciRecursive(int n)
    {
        if (n <= 1)
            return n;
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    static void Main()
    {
        int n = 30; // Change this to test with different values of N
        var startTime = DateTime.Now;
        int result = FibonacciRecursive(n);
        var endTime = DateTime.Now;
        Console.WriteLine($"Fibonacci({n}) = {result}");
        Console.WriteLine("Recursive Fibonacci time: " + (endTime - startTime).TotalMilliseconds + "ms");
    }
}
