using System;

class Program
{
    static void Main()
    {
        int number;
        Console.WriteLine("Enter a number: ");
        number = int.Parse(Console.ReadLine());

        int count = 0;
        int temp = number;
        while (temp != 0)
        {
            temp /= 10;
            count++;
        }

        int[] digits = new int[count];
        temp = number;

        for (int i = 0; i < count; i++)
        {
            digits[i] = temp % 10;
            temp /= 10;
        }

        Console.WriteLine("Reversed Number: ");
        for (int i = 0; i < count; i++)
        {
            Console.Write(digits[i]);
        }
    }
}
