using System;

class FizzBuzz
{
    static void Main(string[] args)
    {
        Console.Write("Enter a positive number: ");
        string input = Console.ReadLine();
        int number;

        if (int.TryParse(input, out number) && number >= 0)
        {
            int i = 1;
            while (i <= number)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
                i++;
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid positive integer.");
        }
    }
}
