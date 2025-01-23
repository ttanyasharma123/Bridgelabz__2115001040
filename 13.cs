using System;

class SumOfNaturalNumbers
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int n;

        if (int.TryParse(Console.ReadLine(), out n) && n > 0)
        {
            int formulaSum = n * (n + 1) / 2;

            int loopSum = 0;
            for (int i = 1; i <= n; i++)
            {
                loopSum += i;
            }

            Console.WriteLine("Sum using formula (n*(n+1)/2): " + formulaSum);
            Console.WriteLine("Sum using for loop: " + loopSum);

            if (formulaSum == loopSum)
            {
                Console.WriteLine("Both computations are correct and match!");
            }
            else
            {
                Console.WriteLine("The computations do not match!");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid positive integer.");
        }
    }
}
