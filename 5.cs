using System;

class NumberChecker
{
    // Main method
    static void Main(string[] args)
    {
        // Get an integer input from the user
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Get the result from the CheckNumber method
        int result = CheckNumber(number);

        // Display the result
        if (result == 1)
        {
            Console.WriteLine("The number is positive.");
        }
        else if (result == -1)
        {
            Console.WriteLine("The number is negative.");
        }
        else
        {
            Console.WriteLine("The number is zero.");
        }
    }

    // Method to check whether the number is positive, negative, or zero
    static int CheckNumber(int number)
    {
        if (number > 0)
        {
            return 1;  // Positive number
        }
        else if (number < 0)
        {
            return -1; // Negative number
        }
        else
        {
            return 0;  // Zero
        }
    }
}
