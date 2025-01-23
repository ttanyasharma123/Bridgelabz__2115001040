using System;

class ArmstrongNumber
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int sum = 0;
        int originalNumber = number;

        while (number != 0)
        {
            int digit = number % 10;
            sum += (int)Math.Pow(digit, 3);
            number /= 10;
        }

        if (sum == originalNumber)
        {
            Console.WriteLine("{originalNumber} is an Armstrong number.");
        }
        else
        {
            Console.WriteLine("{originalNumber} is not an Armstrong number.");
        }
    }
}
