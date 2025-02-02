using System;

class NumberChecker
{
    // Method to find the count of digits in the number
    public static int CountDigits(int number)
    {
        return number.ToString().Length;
    }

    // Method to store the digits of the number in a digits array
    public static int[] StoreDigits(int number)
    {
        string numString = number.ToString();
        int[] digits = new int[numString.Length];
        for (int i = 0; i < numString.Length; i++)
        {
            digits[i] = int.Parse(numString[i].ToString());
        }
        return digits;
    }

    // Method to find the sum of the digits of a number
    public static int SumOfDigits(int number)
    {
        int[] digits = StoreDigits(number);
        int sum = 0;
        foreach (int digit in digits)
        {
            sum += digit;
        }
        return sum;
    }

    // Method to find the sum of the squares of the digits of a number
    public static double SumOfSquaresOfDigits(int number)
    {
        int[] digits = StoreDigits(number);
        double sumOfSquares = 0;
        foreach (int digit in digits)
        {
            sumOfSquares += Math.Pow(digit, 2);
        }
        return sumOfSquares;
    }

    // Method to check if a number is a Harshad number
    public static bool IsHarshadNumber(int number)
    {
        int sumOfDigits = SumOfDigits(number);
        return number % sumOfDigits == 0;
    }

    // Method to find the frequency of each digit in the number
    public static int[,] DigitFrequency(int number)
    {
        int[] digits = StoreDigits(number);
        int[,] frequency = new int[10, 2]; // [digit, frequency] for each digit 0-9
        
        foreach (int digit in digits)
        {
            frequency[digit, 0] = digit; // Store the digit
            frequency[digit, 1]++; // Increase frequency
        }
        
        return frequency;
    }

    // Main method to test the utility methods
    public static void Main()
    {
        int number = 21; // Example number for testing

        // Count of digits
        int digitCount = CountDigits(number);
        Console.WriteLine("Count of digits: " + digitCount);

        // Store the digits in an array
        int[] digits = StoreDigits(number);
        Console.WriteLine("Digits: " + string.Join(", ", digits));

        // Sum of digits
        int sumOfDigits = SumOfDigits(number);
        Console.WriteLine("Sum of digits: " + sumOfDigits);

        // Sum of squares of digits
        double sumOfSquares = SumOfSquaresOfDigits(number);
        Console.WriteLine("Sum of squares of digits: " + sumOfSquares);

        // Check if the number is a Harshad number
        bool isHarshad = IsHarshadNumber(number);
        Console.WriteLine("Is Harshad number: " + isHarshad);

        // Find the frequency of each digit
        int[,] frequencies = DigitFrequency(number);
        Console.WriteLine("Digit Frequencies:");
        for (int i = 0; i < 10; i++)
        {
            if (frequencies[i, 1] > 0)
            {
                Console.WriteLine("Digit " + frequencies[i, 0] + " appears " + frequencies[i, 1] + " times.");
            }
        }
    }
}
