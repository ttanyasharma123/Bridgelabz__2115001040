using System;

class HarshadNumber
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int sum = 0;
        int originalNumber = number;

        if (number == 0)
        {
            Console.WriteLine("0 is not a Harshad number.");
            return;
        }

        while (number != 0)
        {
            sum += number % 10;
            number /= 10;
        }

        if (originalNumber % sum == 0)
        {
            Console.WriteLine(originalNumber + " is a Harshad Number.");
        }
        else
        {
            Console.WriteLine(originalNumber + " is not a Harshad Number.");
        }
    }
}
