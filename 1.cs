using System;

class LeapYearProgram
{
    static void Main()
    {
        Console.Write("Enter a year (>= 1582): ");
        int year = int.Parse(Console.ReadLine());

        if (year < 1582)
        {
            Console.WriteLine("The program only works for years >= 1582.");
        }
        else if (year % 4 == 0 && year % 100 != 0)
        {
            Console.WriteLine("{year} is a Leap Year.");
        }
        else if (year % 400 == 0)
        {
            Console.WriteLine("{year} is a Leap Year.");
        }
        else
        {
            Console.WriteLine("{year} is not a Leap Year.");
        }
    }
}
