using System;

class MultiplicationTable
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number;

        if (int.TryParse(Console.ReadLine(), out number))
        {
            for (int i = 6; i <= 9; i++)
            {
                Console.WriteLine(number + " * " + i + " = " + (number * i));
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }
}
