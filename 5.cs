using System;

class TemperatureConversion
{
    static void Main()
    {
        
        double fahrenheit;

        
        Console.Write("Enter the temperature in Fahrenheit: ");
        fahrenheit = double.Parse(Console.ReadLine());

        
        double celsiusResult = (fahrenheit - 32) * 5 / 9;

        
        Console.WriteLine("{0} Fahrenheit is {1} Celsius", fahrenheit, celsiusResult);
    }
}
