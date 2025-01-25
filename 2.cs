using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[5];
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        foreach (int num in numbers)
        {
            if (num > 0)
            {
                if (num % 2 == 0)
                    Console.WriteLine("The number {0} is positive and even.", num);
                else
                    Console.WriteLine("The number {0} is positive and odd.", num);
            }
            else if (num < 0)
            {
                Console.WriteLine("The number {0} is negative.", num);
            }
            else
            {
                Console.WriteLine("The number {0} is zero.", num);
            }
        }

        if (numbers[0] > numbers[4])
            Console.WriteLine("The first element is greater than the last element.");
        else if (numbers[0] < numbers[4])
            Console.WriteLine("The first element is less than the last element.");
        else
            Console.WriteLine("The first and last elements are equal.");
    }
}
