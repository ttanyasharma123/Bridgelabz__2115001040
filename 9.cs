using System;

class Program
{
    static void Main()
    {
        int number;

        Console.Write("Enter a number: ");
        
        // Check if input is a valid integer
        if (int.TryParse(Console.ReadLine(), out number) && number > 0)
        {
            Console.WriteLine("The factors of " + number + " are:");
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid positive integer.");
        }
    }
}
