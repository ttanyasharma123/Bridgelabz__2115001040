using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        string input = Console.ReadLine();
        int number;

        if (int.TryParse(input, out number) && number > 0)
        {
            string[] results = new string[number + 1];

            for (int i = 1; i <= number; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    results[i] = "FizzBuzz";
                }
                else if (i % 3 == 0)
                {
                    results[i] = "Fizz";
                }
                else if (i % 5 == 0)
                {
                    results[i] = "Buzz";
                }
                else
                {
                    results[i] = i.ToString();
                }
            }

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine("Position " + i + " = " + results[i]);
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid positive integer.");
        }
    }
}
