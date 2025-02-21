using System;

class FinallyBlockDemo
{
    static void Main()
    {
        try
        {
            // Taking user input
            Console.Write("Enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            // Performing division
            int result = num1 / num2;
            Console.WriteLine($"Result: {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid numeric values.");
        }
        finally
        {
            Console.WriteLine("Operation completed.");
        }
    }
}

