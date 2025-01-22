using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter the temperature in Celsius
        Console.Write("Enter the temperature in Celsius: ");
        double celsius = Convert.ToDouble(Console.ReadLine());

        // Convert Celsius to Fahrenheit
        double fahrenheit = (celsius * 9 / 5) + 32;

        Console.WriteLine(fahrenheit);
    }
}

