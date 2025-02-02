using System;

class NaturalNumberSum
{
    // Main method
    static void Main(string[] args)
    {
        // Get the integer input from the user
        Console.Write("Enter a positive integer (n): ");
        int n = Convert.ToInt32(Console.ReadLine());

        // Check if the input is a positive integer
        if (n <= 0)
        {
            Console.WriteLine("Please enter a positive integer.");
        }
        else
        {
            // Call the method to find the sum of n natural numbers
            int sum = FindSum(n);

            // Display the result
            Console.WriteLine("The sum of the first {0} natural numbers is: {1}", n, sum);
        }
    }

    // Method to find the sum of n natural numbers using a loop
    static int FindSum(int n)
    {
        int sum = 0;

        // Loop from 1 to n and add each number to the sum
        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }

        return sum;
    }
}
