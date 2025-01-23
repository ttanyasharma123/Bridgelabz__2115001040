using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        int number;

        if (Int32.TryParse(input, out number))
        {
            int greatestFactor = 1;

            for (int i = number - 1; i >= 1; i--)
            {
                if (number % i == 0)
                {
                    greatestFactor = i;
                    break;
                }
            }

            Console.WriteLine("The greatest factor of " + number + " (besides itself) is " + greatestFactor + ".");
        }
        else
        {
            Console.WriteLine("Please enter a valid integer.");
        }
    }
}
