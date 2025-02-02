using System;

class TriangularParkRun
{
    // Main method
    static void Main(string[] args)
    {
        // Get the sides of the triangle from the user
        Console.Write("Enter the length of the first side of the triangle (in meters): ");
        double side1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the length of the second side of the triangle (in meters): ");
        double side2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the length of the third side of the triangle (in meters): ");
        double side3 = Convert.ToDouble(Console.ReadLine());

        // Calculate the perimeter of the triangle
        double perimeter = CalculatePerimeter(side1, side2, side3);

        // Calculate the number of rounds to complete 5 kilometers
        double rounds = CalculateRounds(5000, perimeter); // 5000 meters (5 km)

        // Display the result
        Console.WriteLine("The athlete needs to complete {0} rounds to run 5 kilometers.", Math.Ceiling(rounds));
    }

    // Method to calculate the perimeter of the triangle
    static double CalculatePerimeter(double side1, double side2, double side3)
    {
        return side1 + side2 + side3;
    }

    // Method to calculate the number of rounds required to complete a certain distance
    static double CalculateRounds(double totalDistance, double perimeter)
    {
        return totalDistance / perimeter;
    }
}
