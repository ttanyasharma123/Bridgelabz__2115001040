using System;

class BMICalculator
{
    static void Main()
    {
        Console.Write("Enter your weight in kilograms: ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Enter your height in centimeters: ");
        double heightCm = double.Parse(Console.ReadLine());

        double heightM = heightCm / 100;
        double bmi = weight / (heightM * heightM);

        Console.WriteLine("Your BMI is: " + bmi.ToString("F2"));

        if (bmi <= 18.4)
        {
            Console.WriteLine("Status: Underweight");
        }
        else if (bmi >= 18.5 && bmi <= 24.9)
        {
            Console.WriteLine("Status: Normal");
        }
        else if (bmi >= 25.0 && bmi <= 39.9)
        {
            Console.WriteLine("Status: Overweight");
        }
        else if (bmi >= 40.0)
        {
            Console.WriteLine("Status: Obese");
        }
    }
}
