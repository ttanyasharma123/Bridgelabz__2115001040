using System;

class FactorCalculator
{
    public static void Main()
    {
        // Taking input from the user
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        // Finding the factors of the number
        int[] factors = GetFactors(number);

        // Displaying the factors
        Console.WriteLine("Factors: ");
        foreach (int factor in factors)
        {
            Console.Write(factor + " ");
        }
        Console.WriteLine();

        // Calculating and displaying the sum of the factors
        Console.WriteLine("Sum of factors: " + GetSum(factors));

        // Calculating and displaying the sum of squares of the factors
        Console.WriteLine("Sum of squares of factors: " + GetSumOfSquares(factors));

        // Calculating and displaying the product of the factors
        Console.WriteLine("Product of factors: " + GetProduct(factors));
    }

    // Method to find factors of the number and return them in an array
    static int[] GetFactors(int number)
    {
        int count = 0;
        
        // First loop to count the factors
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                count++;
            }
        }

        // Initialize the array to store factors
        int[] factors = new int[count];
        int index = 0;

        // Second loop to store the factors in the array
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                factors[index++] = i;
            }
        }

        return factors;
    }

    // Method to calculate the sum of the factors
    static int GetSum(int[] factors)
    {
        int sum = 0;
        foreach (int factor in factors)
        {
            sum += factor;
        }
        return sum;
    }

    // Method to calculate the product of the factors
    static int GetProduct(int[] factors)
    {
        int product = 1;
        foreach (int factor in factors)
        {
            product *= factor;
        }
        return product;
    }

    // Method to calculate the sum of squares of the factors
    static double GetSumOfSquares(int[] factors)
    {
        double sumOfSquares = 0;
        foreach (int factor in factors)
        {
            sumOfSquares += Math.Pow(factor, 2);
        }
        return sumOfSquares;
    }
}
