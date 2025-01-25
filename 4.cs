using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int[] multiplicationTable = new int[10];

        for (int i = 1; i <= 10; i++)
        {
            multiplicationTable[i - 1] = number * i;
        }

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("{0} * {1} = {2}", number, i, multiplicationTable[i - 1]);
        }
    }
}
