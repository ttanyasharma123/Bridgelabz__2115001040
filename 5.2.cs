using System;

class Program
{
    public static int FibonacciIterative(int n)
    {
        int a = 0, b = 1, sum;
        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }
        return b;
    }

    static void Main()
    {
        int n = 30; // Change this to test with different values of N
        var startTime = DateTime.Now;
        int result = FibonacciIterative(n);
        var endTime = DateTime.Now;
        Console.WriteLine($"Fibonacci({n}) = {result}");
        Console.WriteLine("Iterative Fibonacci time: " + (endTime - startTime).TotalMilliseconds + "ms");
    }
}
