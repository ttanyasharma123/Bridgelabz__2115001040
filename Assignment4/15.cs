using System;

class FactorialCalculator
{
    static void Main(string[] args)
    {
        Console.Write("Enter a positive integer: ");
        int n;
        if (int.TryParse(Console.ReadLine(), out n) && n >= 0)
        {
            long factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine("The factorial of " + n + " is: " + factorial);
        }
        else
        {
            Console.WriteLine("Please enter a valid positive integer.");
        }
    }
}
