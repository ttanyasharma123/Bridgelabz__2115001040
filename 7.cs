using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a natural number: ");
        int number = int.Parse(Console.ReadLine());

        if (number <= 0)
        {
            Console.WriteLine("Error: The input must be a natural number (greater than 0).");
            return;
        }

        int[] evenNumbers = new int[number / 2 + 1];
        int[] oddNumbers = new int[number / 2 + 1];
        int evenIndex = 0, oddIndex = 0;

        for (int i = 1; i <= number; i++)
        {
            if (i % 2 == 0)
            {
                evenNumbers[evenIndex] = i;
                evenIndex++;
            }
            else
            {
                oddNumbers[oddIndex] = i;
                oddIndex++;
            }
        }

        Console.WriteLine("Odd Numbers:");
        for (int i = 0; i < oddIndex; i++)
        {
            Console.Write(oddNumbers[i] + " ");
        }

        Console.WriteLine("\nEven Numbers:");
        for (int i = 0; i < evenIndex; i++)
        {
            Console.Write(evenNumbers[i] + " ");
        }
    }
}
