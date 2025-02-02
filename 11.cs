using System;

class WindChillCalculator
{
    // Main method
    static void Main(string[] args)
    {
        // Get temperature and wind speed as input from the user
        Console.Write("Enter the temperature in Fahrenheit (should be less than 50°F): ");
        double temperature = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the wind speed in miles per hour (should be between 3 and 120 mph): ");
        double windSpeed = Convert.ToDouble(Console.ReadLine());

        // Validate the inputs for temperature and wind speed
        if (temperature > 50)
        {
            Console.WriteLine("Temperature must be less than 50°F.");
            return;
        }
        if (windSpeed < 3 || windSpeed > 120)
        {
            Console.WriteLine("Wind speed must be between 3 and 120 mph.");
            return;
        }

        // Call the method to calculate wind chill temperature
        double windChill = CalculateWindChill(temperature, windSpeed);

        // Display the wind chill temperature
        Console.WriteLine("The wind chill temperature is: {0:F2}°F", windChill);
    }

    // Method to calculate the wind chill temperature
    public static double CalculateWindChill(double temperature, double windSpeed)
    {
        return 35.74 + 0.6215 * temperature + (0.4275 * temperature - 35.75) * Math.Pow(windSpeed, 0.16);
    }
}
