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
            int i = 1;

            while (i <= n)
            {
                factorial *= i;
                i++;
            }

            Console.WriteLine("The factorial of " + n + " is: " + factorial);
        }
        else
        {
            Console.WriteLine("Please enter a valid positive integer.");
        }
    }
}
