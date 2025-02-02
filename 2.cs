using System;

class NaturalNumberSum
{
    public static void Main()
    {
        // Take input from the user
        Console.Write("Enter a natural number: ");
        string input = Console.ReadLine();

        // Check if the input is a valid natural number
        int n;
        if (int.TryParse(input, out n) && n > 0)
        {
            // Call the recursive method to calculate the sum
            int recursiveSum = SumUsingRecursion(n);

            // Call the formula method to calculate the sum
            int formulaSum = SumUsingFormula(n);

            // Display the results using concatenation instead of interpolation
            Console.WriteLine("Sum using recursion: " + recursiveSum);
            Console.WriteLine("Sum using formula (n*(n+1)/2): " + formulaSum);

            // Compare the results
            if (recursiveSum == formulaSum)
            {
                Console.WriteLine("The results match, both computations are correct.");
            }
            else
            {
                Console.WriteLine("The results do not match, there is an error.");
            }
        }
        else
        {
            // If input is not a valid natural number, exit the program
            Console.WriteLine("Invalid input. Please enter a valid natural number.");
        }
    }

    // Method to find the sum of n natural numbers using recursion
    static int SumUsingRecursion(int n)
    {
        // Base case: if n is 1, return 1 (sum of first 1 natural number)
        if (n == 1)
        {
            return 1;
        }
        // Recursive case: sum of n + sum of (n-1)
        else
        {
            return n + SumUsingRecursion(n - 1);
        }
    }

    // Method to find the sum of n natural numbers using the formula n*(n+1)/2
    static int SumUsingFormula(int n)
    {
        // Return the sum calculated using the formula
        return n * (n + 1) / 2;
    }
}
