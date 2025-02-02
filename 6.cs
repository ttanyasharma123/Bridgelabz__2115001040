using System;
using System.Collections.Generic;

public static class NumberChecker
{
    /// <summary>
    /// Finds and returns the factors of a number as an array.
    /// </summary>
    public static int[] FindFactors(int number)
    {
        int factorCount = 0;

        // First loop to count the factors
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                factorCount++;
        }

        int[] factors = new int[factorCount];
        int index = 0;

        // Second loop to populate the factors
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                factors[index++] = i;
        }

        return factors;
    }

    /// <summary>
    /// Finds the greatest factor of a number using the factors array.
    /// </summary>
    public static int FindGreatestFactor(int[] factors)
    {
        return factors[factors.Length - 1];
    }

    /// <summary>
    /// Finds and returns the sum of the factors.
    /// </summary>
    public static int FindSumOfFactors(int[] factors)
    {
        int sum = 0;
        foreach (int factor in factors)
        {
            sum += factor;
        }
        return sum;
    }

    /// <summary>
    /// Finds and returns the product of the factors.
    /// </summary>
    public static int FindProductOfFactors(int[] factors)
    {
        int product = 1;
        foreach (int factor in factors)
        {
            product *= factor;
        }
        return product;
    }

    /// <summary>
    /// Finds and returns the product of the cubes of the factors.
    /// </summary>
    public static double FindProductOfCubesOfFactors(int[] factors)
    {
        double product = 1;
        foreach (int factor in factors)
        {
            product *= Math.Pow(factor, 3);
        }
        return product;
    }

    /// <summary>
    /// Checks if a number is a perfect number.
    /// </summary>
    public static bool IsPerfectNumber(int number)
    {
        int[] factors = FindFactors(number);
        int sum = 0;

        foreach (int factor in factors)
        {
            if (factor != number)
                sum += factor; // Proper divisors
        }

        return sum == number;
    }

    /// <summary>
    /// Checks if a number is an abundant number.
    /// </summary>
    public static bool IsAbundantNumber(int number)
    {
        int[] factors = FindFactors(number);
        int sum = 0;

        foreach (int factor in factors)
        {
            if (factor != number)
                sum += factor; // Proper divisors
        }

        return sum > number;
    }

    /// <summary>
    /// Checks if a number is a deficient number.
    /// </summary>
    public static bool IsDeficientNumber(int number)
    {
        int[] factors = FindFactors(number);
        int sum = 0;

        foreach (int factor in factors)
        {
            if (factor != number)
                sum += factor; // Proper divisors
        }

        return sum < number;
    }

    /// <summary>
    /// Checks if a number is a strong number.
    /// </summary>
    public static bool IsStrongNumber(int number)
    {
        int originalNumber = number;
        int sum = 0;

        while (number > 0)
        {
            int digit = number % 10;
            sum += Factorial(digit);
            number /= 10;
        }

        return sum == originalNumber;
    }

    /// <summary>
    /// Helper method to calculate the factorial of a number.
    /// </summary>
    private static int Factorial(int num)
    {
        int result = 1;
        for (int i = 2; i <= num; i++)
        {
            result *= i;
        }
        return result;
    }

    /// <summary>
    /// Main method to demonstrate the functionality of the NumberChecker class.
    /// </summary>
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number to analyze:");
        int inputNumber = int.Parse(Console.ReadLine());

        int[] factors = FindFactors(inputNumber);

        Console.WriteLine("Factors: " + string.Join(", ", factors));
        Console.WriteLine("Greatest Factor: " + FindGreatestFactor(factors));
        Console.WriteLine("Sum of Factors: " + FindSumOfFactors(factors));
        Console.WriteLine("Product of Factors: " + FindProductOfFactors(factors));
        Console.WriteLine("Product of Cubes of Factors: " + FindProductOfCubesOfFactors(factors));
        Console.WriteLine("Is Perfect Number: " + (IsPerfectNumber(inputNumber) ? "Yes" : "No"));
        Console.WriteLine("Is Abundant Number: " + (IsAbundantNumber(inputNumber) ? "Yes" : "No"));
        Console.WriteLine("Is Deficient Number: " + (IsDeficientNumber(inputNumber) ? "Yes" : "No"));
        Console.WriteLine("Is Strong Number: " + (IsStrongNumber(inputNumber) ? "Yes" : "No"));
    }
}
