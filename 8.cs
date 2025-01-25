using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        if (number <= 0)
        {
            Console.WriteLine("Error: Please enter a positive number.");
            return;
        }

        int maxFactor = 10;
        int[] factors = new int[maxFactor];
        int index = 0;

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                if (index == maxFactor)
                {
                    maxFactor *= 2;
                    int[] temp = new int[maxFactor];
                    for (int j = 0; j < factors.Length; j++)
                    {
                        temp[j] = factors[j];
                    }
                    factors = temp;
                }
                factors[index] = i;
                index++;
            }
        }

        Console.WriteLine("Factors of {0}:", number);
        for (int i = 0; i < index; i++)
        {
            Console.Write(factors[i] + " ");
        }
    }
}
