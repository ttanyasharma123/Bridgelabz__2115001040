using System;

/// <summary>
/// Utility class for checking different properties of numbers.
/// </summary>
public class NumberChecker
{
    /// <summary>
    /// Checks if a number is a prime number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if the number is prime, otherwise false.</returns>
    public static bool IsPrimeNumber(int number)
    {
        if (number <= 1) return false;
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            if (number % divisor == 0) return false;
        return true;
    }

    /// <summary>
    /// Checks if a number is a neon number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if the number is neon, otherwise false.</returns>
    public static bool IsNeonNumber(int number)
    {
        int square = number * number;
        int sumOfDigits = 0;
        while (square > 0)
        {
            sumOfDigits += square % 10;
            square /= 10;
        }
        return sumOfDigits == number;
    }

    /// <summary>
    /// Checks if a number is a spy number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if the number is a spy number, otherwise false.</returns>
    public static bool IsSpyNumber(int number)
    {
        int sumOfDigits = 0, productOfDigits = 1;
        while (number > 0)
        {
            int digit = number % 10;
            sumOfDigits += digit;
            productOfDigits *= digit;
            number /= 10;
        }
        return sumOfDigits == productOfDigits;
    }

    /// <summary>
    /// Checks if a number is an automorphic number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if the number is automorphic, otherwise false.</returns>
    public static bool IsAutomorphicNumber(int number)
    {
        int square = number * number;
        return square.ToString().EndsWith(number.ToString());
    }

    /// <summary>
    /// Checks if a number is a buzz number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if the number is a buzz number, otherwise false.</returns>
    public static bool IsBuzzNumber(int number)
    {
        return number % 7 == 0 || number % 10 == 7;
    }

    /// <summary>
    /// Main method to demonstrate the functionality of the NumberChecker class.
    /// </summary>
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number to check its properties:");
        int inputNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Results:");
        Console.WriteLine("Is Prime: " + IsPrimeNumber(inputNumber));
        Console.WriteLine("Is Neon: " + IsNeonNumber(inputNumber));
        Console.WriteLine("Is Spy: " + IsSpyNumber(inputNumber));
        Console.WriteLine("Is Automorphic: " + IsAutomorphicNumber(inputNumber));
        Console.WriteLine("Is Buzz: " + IsBuzzNumber(inputNumber));
    }
}
