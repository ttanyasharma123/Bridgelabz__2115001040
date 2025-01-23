using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the first number: ");
        int number1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        int number2 = int.Parse(Console.ReadLine());

        Console.Write("Enter the third number: ");
        int number3 = int.Parse(Console.ReadLine());

        if (number1 < number2 && number1 < number3)
        {
            Console.WriteLine("Is the first number the smallest? Yes");
        }
        else
        {
            Console.WriteLine("Is the first number the smallest? No");
        }
    }
}
