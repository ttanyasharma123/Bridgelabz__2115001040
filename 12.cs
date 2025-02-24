using System;
using System.Diagnostics;
using System.Reflection;

class MethodTimer
{
    public static void MeasureExecutionTime(object obj, string methodName, object[] parameters)
    {
        // Get the type of the object
        Type type = obj.GetType();

        // Get the method using Reflection
        MethodInfo method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);

        if (method == null)
        {
            Console.WriteLine($"Method '{methodName}' not found in {type.Name}");
            return;
        }

        // Start measuring time
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Invoke the method dynamically
        object result = method.Invoke(obj, parameters);

        // Stop measuring time
        stopwatch.Stop();

        // Display execution time
        Console.WriteLine($"Execution time of {methodName}: {stopwatch.ElapsedMilliseconds} ms");

        // Display result if method has a return value
        if (result != null)
        {
            Console.WriteLine($"Result: {result}");
        }
    }
}

// Sample class with methods to test execution timing
class TestClass
{
    public void FastMethod()
    {
        Console.WriteLine("Executing FastMethod...");
    }

    public void SlowMethod()
    {
        Console.WriteLine("Executing SlowMethod...");
        System.Threading.Thread.Sleep(2000); // Simulate a slow operation
    }

    public int Sum(int a, int b)
    {
        return a + b;
    }
}

class Program
{
    static void Main()
    {
        TestClass testObj = new TestClass();

        // Measure execution time of different methods
        MethodTimer.MeasureExecutionTime(testObj, "FastMethod", null);
        MethodTimer.MeasureExecutionTime(testObj, "SlowMethod", null);
        MethodTimer.MeasureExecutionTime(testObj, "Sum", new object[] { 5, 10 });
    }
}



