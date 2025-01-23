using System;

class AbundantNumber
{
    static void Main()
    {
        try
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            if (number <= 0)
            {
                Console.WriteLine("Please enter a positive number.");
                return;
            }

            int sum = 0;

            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }

            if (sum > number)
            {
                Console.WriteLine(number + " is an Abundant Number.");
            }
            else
            {
                Console.WriteLine(number + " is not an Abundant Number.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}
