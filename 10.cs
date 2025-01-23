using System;

class Program
{
    static void Main()
    {
        int number;

        Console.Write("Enter a number: ");
        
        if (int.TryParse(Console.ReadLine(), out number) && number > 0)
        {
            Console.WriteLine("The multiples of " + number + " below 100 are:");
            
            for (int i = 100; i >= 1; i--)
            {
                if (i % number == 0)
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
