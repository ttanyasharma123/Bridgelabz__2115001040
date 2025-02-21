using System;

class ExceptionPropagationDemo
{
    // Method1: Throws an ArithmeticException (division by zero)
    static void Method1()
    {
        int result = 10 / 0; // This will throw a DivideByZeroException
    }

    // Method2: Calls Method1()
    static void Method2()
    {
        Method1(); // Exception propagates to this method
    }

    static void Main()
    {
        try
        {
            Method2(); // Calls Method2, which calls Method1
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Handled exception in Main.");
        }
        finally
        {
            Console.WriteLine("Program execution completed.");
        }
    }
}

