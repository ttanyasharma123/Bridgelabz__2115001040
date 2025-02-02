using System;

public class NumberChecker
{
    // Method to check if a number is positive or negative
    public static string IsPositiveOrNegative(int number)
    {
        if (number < 0)
        {
            return "Negative";
        }
        else
        {
            return "Positive";
        }
    }

    // Method to check if a number is even or odd
    public static string IsEvenOrOdd(int number)
    {
        if (number % 2 == 0)
        {
            return "Even";
        }
        else
        {
            return "Odd";
        }
    }

    // Method to compare two numbers and return 1 if number1 > number2, 0 if equal, or -1 if number1 < number2
    public static int CompareNumbers(int num1, int num2)
    {
        if (num1 > num2)
        {
            return 1;
        }
        else if (num1 == num2)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    // Main method
    public static void Main()
    {
        // Declare an array to store 5 numbers
        int[] numbers = new int[5];

        // Take user input for 5 numbers
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number " + (i + 1) + ": ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Loop through the array and check if the number is positive/negative and even/odd
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine("Number " + (i + 1) + ": " + numbers[i]);
            
            // Check if the number is positive or negative
            string result = IsPositiveOrNegative(numbers[i]);
            Console.WriteLine(result);

            // If positive, check if it's even or odd
            if (result == "Positive")
            {
                string evenOddResult = IsEvenOrOdd(numbers[i]);
                Console.WriteLine(evenOddResult);
            }
        }

        // Compare the first and last elements of the array
        int comparisonResult = CompareNumbers(numbers[0], numbers[numbers.Length - 1]);

        // Display comparison result
        if (comparisonResult == 1)
        {
            Console.WriteLine("The first number is greater than the last number.");
        }
        else if (comparisonResult == 0)
        {
            Console.WriteLine("The first and last numbers are equal.");
        }
        else
        {
            Console.WriteLine("The first number is less than the last number.");
        }
    }
}
