using System;

class TemperatureConversion
{
    static void Main()
    {
        
        double celsius;

        
        Console.Write("Enter the temperature in Celsius: ");
        celsius = double.Parse(Console.ReadLine());

        
        double fahrenheitResult = (celsius * 9 / 5) + 32;

        
        Console.WriteLine("{0} Celsius is {1} Fahrenheit", celsius, fahrenheitResult);
    }
}
