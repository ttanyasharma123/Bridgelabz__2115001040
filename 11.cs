using System;

class SumUntilNegative
{
    static void Main(string[] args)
    {
        double total = 0.0;
        double number;

        while (true)
        {
            Console.Write("Enter a number (enter 0 or a negative number to stop): ");
            number = double.Parse(Console.ReadLine());

            if (number <= 0)
            {
                break;
            }

            total += number;
        }

        Console.WriteLine("The total sum is: {total}");
    }
}
