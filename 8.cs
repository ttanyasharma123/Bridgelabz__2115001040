using System;

class TripDetails
{
    static void Main()
    {
        // Declare variables for user inputs
        string name, fromCity, viaCity, toCity;
        double fromToVia, viaToFinalCity, totalDistance, averageSpeed;
        double timeTaken;

        // Take user inputs for name, cities, and distances
        Console.Write("Enter your name: ");
        name = Console.ReadLine();

        Console.Write("Enter the name of your starting city: ");
        fromCity = Console.ReadLine();

        Console.Write("Enter the name of the via city: ");
        viaCity = Console.ReadLine();

        Console.Write("Enter the name of your final destination city: ");
        toCity = Console.ReadLine();

        Console.Write("Enter the distance (in miles) from {0} to {1}: ", fromCity, viaCity);
        fromToVia = double.Parse(Console.ReadLine());

        Console.Write("Enter the distance (in miles) from {0} to {1}: ", viaCity, toCity);
        viaToFinalCity = double.Parse(Console.ReadLine());

        // Calculate total distance
        totalDistance = fromToVia + viaToFinalCity;

        Console.Write("Enter the time taken for the journey (in hours): ");
        timeTaken = double.Parse(Console.ReadLine());

        // Calculate average speed
        averageSpeed = totalDistance / timeTaken;

        // Print the results
        Console.WriteLine("\nThe results of the trip are:");
        Console.WriteLine("Traveler: {0}", name);
        Console.WriteLine("Total distance covered: {0} miles", totalDistance);
        Console.WriteLine("Average speed during the journey: {0} miles per hour", averageSpeed);
    }
}
