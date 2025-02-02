using System;

class TrigonometricFunctions
{
    // Main method
    static void Main(string[] args)
    {
        // Get angle input from the user in degrees
        Console.Write("Enter the angle in degrees: ");
        double angleInDegrees = Convert.ToDouble(Console.ReadLine());

        // Call the method to calculate trigonometric functions
        double[] results = CalculateTrigonometricFunctions(angleInDegrees);

        // Display the results
        Console.WriteLine("Trigonometric values for the angle {0}°:", angleInDegrees);
        Console.WriteLine("Sine: {0:F4}", results[0]);
        Console.WriteLine("Cosine: {0:F4}", results[1]);
        Console.WriteLine("Tangent: {0:F4}", results[2]);
    }

    // Method to calculate trigonometric functions
    public static double[] CalculateTrigonometricFunctions(double angle)
    {
        // Convert the angle from degrees to radians
        double angleInRadians = angle * (Math.PI / 180);

        // Calculate sine, cosine, and tangent
        double sine = Math.Sin(angleInRadians);
        double cosine = Math.Cos(angleInRadians);
        double tangent;

        // Handle undefined tangent cases when cosine is zero
        if (Math.Abs(cosine) < 1e-10) // If cosine is effectively zero
        {
            tangent = double.NaN; // Tangent is undefined
        }
        else
        {
            tangent = Math.Tan(angleInRadians);
        }

        // Return results as an array
        return new double[] { sine, cosine, tangent };
    }
}
