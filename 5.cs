using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int[] multiplicationResult = new int[4];

        for (int i = 6; i <= 9; i++)
        {
            multiplicationResult[i - 6] = number * i;
            Console.WriteLine("{0} * {1} = {2}", number, i, multiplicationResult[i - 6]);
        }
    }
}
