using System;

class OddEvenNumbers
{
    static void Main(string[] args)
    {
        Console.Write("Enter a positive integer: ");
        int number;

        if (int.TryParse(Console.ReadLine(), out number) && number > 0)
        {
            for (int i = 1; i <= number; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i + " is an even number.");
                }
                else
                {
                    Console.WriteLine(i + " is an odd number.");
                }
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid positive integer.");
        }
    }
}
