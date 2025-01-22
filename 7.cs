using System;

class SwapNumbers
{
    static void Main()
    {
        // Declare variables for two numbers
        int number1, number2, temp;

        // Take user input for number1
        Console.Write("Enter the first number: ");
        number1 = int.Parse(Console.ReadLine());

        // Take user input for number2
        Console.Write("Enter the second number: ");
        number2 = int.Parse(Console.ReadLine());

        // Swap the numbers using a temporary variable
        temp = number1;
        number1 = number2;
        number2 = temp;

        // Print the swapped numbers
        Console.WriteLine("The swapped numbers are {0} and {1}", number1, number2);
    }
}
