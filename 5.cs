using System;

public class UnitConverter
{
    // Method to convert yards to feet
    public static double ConvertYardsToFeet(double yards)
    {
        double yardsToFeet = 3; // 1 yard = 3 feet
        return yards * yardsToFeet;
    }

    // Method to convert feet to yards
    public static double ConvertFeetToYards(double feet)
    {
        double feetToYards = 0.333333; // 1 foot = 0.333333 yards
        return feet * feetToYards;
    }

    // Method to convert meters to inches
    public static double ConvertMetersToInches(double meters)
    {
        double metersToInches = 39.3701; // 1 meter = 39.3701 inches
        return meters * metersToInches;
    }

    // Method to convert inches to meters
    public static double ConvertInchesToMeters(double inches)
    {
        double inchesToMeters = 0.0254; // 1 inch = 0.0254 meters
        return inches * inchesToMeters;
    }

    // Method to convert inches to centimeters
    public static double ConvertInchesToCentimeters(double inches)
    {
        double inchesToCm = 2.54; // 1 inch = 2.54 cm
        return inches * inchesToCm;
    }

    // Main method to test the conversion methods
    public static void Main()
    {
        // Test the conversion methods with some example inputs
        double yards = 10;
        double feet = 30;
        double meters = 5;
        double inches = 12;

        // Perform conversions and output results using basic string concatenation
        Console.WriteLine(yards + " yards is equal to " + ConvertYardsToFeet(yards) + " feet.");
        Console.WriteLine(feet + " feet is equal to " + ConvertFeetToYards(feet) + " yards.");
        Console.WriteLine(meters + " meters is equal to " + ConvertMetersToInches(meters) + " inches.");
        Console.WriteLine(inches + " inches is equal to " + ConvertInchesToMeters(inches) + " meters.");
        Console.WriteLine(inches + " inches is equal to " + ConvertInchesToCentimeters(inches) + " centimeters.");
    }
}
