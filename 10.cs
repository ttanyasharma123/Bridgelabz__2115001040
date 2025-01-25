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

        int[] frequency = new int[10];

        for (int i = 0; i < count; i++)
        {
            frequency[digits[i]]++;
        }

        Console.WriteLine("Frequency of each digit:");
        for (int i = 0; i < 10; i++)
        {
            if (frequency[i] > 0)
            {
                Console.WriteLine(i + ": " + frequency[i]);
            }
        }
    }
}
