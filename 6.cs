using System;

public class UnitConverter
{
    // Method to convert Fahrenheit to Celsius
    public static double ConvertFahrenheitToCelsius(double fahrenheit)
    {
        double fahrenheitToCelsius = (fahrenheit - 32) * 5 / 9; // Formula to convert Fahrenheit to Celsius
        return fahrenheitToCelsius;
    }

    // Method to convert Celsius to Fahrenheit
    public static double ConvertCelsiusToFahrenheit(double celsius)
    {
        double celsiusToFahrenheit = (celsius * 9 / 5) + 32; // Formula to convert Celsius to Fahrenheit
        return celsiusToFahrenheit;
    }

    // Method to convert pounds to kilograms
    public static double ConvertPoundsToKilograms(double pounds)
    {
        double poundsToKilograms = 0.453592; // Conversion factor: 1 pound = 0.453592 kilograms
        return pounds * poundsToKilograms;
    }

    // Method to convert kilograms to pounds
    public static double ConvertKilogramsToPounds(double kilograms)
    {
        double kilogramsToPounds = 2.20462; // Conversion factor: 1 kilogram = 2.20462 pounds
        return kilograms * kilogramsToPounds;
    }

    // Method to convert gallons to liters
    public static double ConvertGallonsToLiters(double gallons)
    {
        double gallonsToLiters = 3.78541; // Conversion factor: 1 gallon = 3.78541 liters
        return gallons * gallonsToLiters;
    }

    // Method to convert liters to gallons
    public static double ConvertLitersToGallons(double liters)
    {
        double litersToGallons = 0.264172; // Conversion factor: 1 liter = 0.264172 gallons
        return liters * litersToGallons;
    }

    // Main method to test the conversion methods
    public static void Main()
    {
        // Test the conversion methods with some example inputs
        double fahrenheit = 98.6;
        double celsius = 37;
        double pounds = 150;
        double kilograms = 68;
        double gallons = 5;
        double liters = 18.9;

        // Perform conversions and output results
        Console.WriteLine(fahrenheit + " Fahrenheit is equal to " + ConvertFahrenheitToCelsius(fahrenheit) + " Celsius.");
        Console.WriteLine(celsius + " Celsius is equal to " + ConvertCelsiusToFahrenheit(celsius) + " Fahrenheit.");
        Console.WriteLine(pounds + " pounds is equal to " + ConvertPoundsToKilograms(pounds) + " kilograms.");
        Console.WriteLine(kilograms + " kilograms is equal to " + ConvertKilogramsToPounds(kilograms) + " pounds.");
        Console.WriteLine(gallons + " gallons is equal to " + ConvertGallonsToLiters(gallons) + " liters.");
        Console.WriteLine(liters + " liters is equal to " + ConvertLitersToGallons(liters) + " gallons.");
    }
}
