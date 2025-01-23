using System;

class SumOfNumbers
{
    static void Main(string[] args)
    {
        double total = 0.0;
        double number;

        while (true)
        {
            Console.Write("Enter a number (or 0 to stop): ");
            number = double.Parse(Console.ReadLine());

            if (number == 0)
            {
                break;
            }

            total += number;
        }

        Console.WriteLine("The total sum is: {total}");
    }
}
