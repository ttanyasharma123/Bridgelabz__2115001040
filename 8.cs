using System;

class QuotientAndRemainder
{
    // Main method
    static void Main(string[] args)
    {
        // Get the dividend and divisor as input from the user
        Console.Write("Enter the dividend (number): ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the divisor: ");
        int divisor = Convert.ToInt32(Console.ReadLine());

        // Check if the divisor is zero to avoid division by zero
        if (divisor == 0)
        {
            Console.WriteLine("Division by zero is not allowed. Please enter a non-zero divisor.");
            return;
        }

        // Call the method to find the quotient and remainder
        int[] result = FindRemainderAndQuotient(number, divisor);

        // Display the results
        Console.WriteLine("The quotient is: " + result[0]);
        Console.WriteLine("The remainder is: " + result[1]);
    }

    // Method to calculate the quotient and remainder
    public static int[] FindRemainderAndQuotient(int number, int divisor)
    {
        int quotient = number / divisor;
        int remainder = number % divisor;

        // Return both values as an array
        return new int[] { quotient, remainder };
    }
}
