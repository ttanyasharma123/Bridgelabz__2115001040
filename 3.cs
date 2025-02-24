using System;
using System.Reflection;

class Calculator
{
    private int Multiply(int a, int b)
    {
        return a * b;
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();
        
        // Get the type of the Calculator class
        Type type = typeof(Calculator);

        // Get the private method "Multiply" using Reflection
        MethodInfo multiplyMethod = type.GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance);

        if (multiplyMethod != null)
        {
            // Invoke the private method on the instance of Calculator
            object result = multiplyMethod.Invoke(calc, new object[] { 5, 3 });

            // Display the result
            Console.WriteLine("Multiplication Result: " + result);
        }
        else
        {
            Console.WriteLine("Method not found!");
        }
    }
}


