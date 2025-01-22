using System;

class FeetConversion
{
    static void Main()
    {
        Console.Write("Enter the distance in feet: ");
        double distanceInFeet = Convert.ToDouble(Console.ReadLine());

        double yards = distanceInFeet / 3;
        double miles = yards / 1760;

        Console.WriteLine("The distance in yards is {yards:F2} and in miles is {miles:F2}");
    }
}

