using System;

class DistanceConversion
{
    static void Main()
    {
        Console.Write("Enter distance in kilometers: ");
        double km = Convert.ToDouble(Console.ReadLine());
        double miles = km / 1.6;

        Console.WriteLine("The total miles is {miles:F2} mile for the given {km} km");
    }
}

