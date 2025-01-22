using System;

class WeightConversion
{
    static void Main()
    {
       
        double weightInPounds, weightInKilograms;

        
        Console.Write("Enter the weight in pounds: ");
        weightInPounds = double.Parse(Console.ReadLine());

        
        weightInKilograms = weightInPounds * 2.2;

        
        Console.WriteLine("The weight of the person in pounds is {0} and in kg is {1}.", weightInPounds, weightInKilograms);
    }
}
