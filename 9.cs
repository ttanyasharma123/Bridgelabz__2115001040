using System;

class AthleteRun
{
    static void Main()
    {
        
        double side1, side2, side3;
        double perimeter, totalDistance = 5000; 

        
        Console.Write("Enter the length of side 1 (in meters): ");
        side1 = double.Parse(Console.ReadLine());

        Console.Write("Enter the length of side 2 (in meters): ");
        side2 = double.Parse(Console.ReadLine());

        Console.Write("Enter the length of side 3 (in meters): ");
        side3 = double.Parse(Console.ReadLine());

        
        perimeter = side1 + side2 + side3;

        
        double rounds = totalDistance / perimeter;

      
        Console.WriteLine("The total number of rounds the athlete will run is {0} to complete 5 km.", Math.Ceiling(rounds));
    }
}
