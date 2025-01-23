using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number;
        if (int.TryParse(Console.ReadLine(), out number))
        {
            if (number % 5 == 0)
            {
                Console.WriteLine("Is the number {number} divisible by 5? Yes");
            }
            else
            {
                Console.WriteLine("Is the number {number} divisible by 5? No");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}

