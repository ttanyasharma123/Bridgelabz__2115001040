using System;

public class BMICalculator
{
    public static void Main()
    {
        double[,] personData = new double[10, 3]; // 10 people, 3 columns (weight, height, BMI)
        string[] status = new string[10]; // To store the BMI status for each person
        
        // Get input from the user for weight and height
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Enter the weight (in kg) for person " + (i + 1) + ": ");
            personData[i, 0] = Convert.ToDouble(Console.ReadLine()); // weight
            Console.WriteLine("Enter the height (in cm) for person " + (i + 1) + ": ");
            personData[i, 1] = Convert.ToDouble(Console.ReadLine()); // height
        }
        
        // Calculate BMI and store in the third column
        for (int i = 0; i < 10; i++)
        {
            personData[i, 2] = CalculateBMI(personData[i, 0], personData[i, 1]);
        }
        
        // Determine the BMI status for each person
        for (int i = 0; i < 10; i++)
        {
            status[i] = GetBMIStatus(personData[i, 2]);
        }
        
        // Display the results for each person
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Person " + (i + 1) + ": Weight = " + personData[i, 0] + " kg, Height = " + personData[i, 1] + " cm, BMI = " + personData[i, 2] + ", Status = " + status[i]);
        }
    }
    
    // Method to calculate BMI
    public static double CalculateBMI(double weight, double height)
    {
        double heightInMeters = height / 100; // Convert cm to meters
        return weight / (heightInMeters * heightInMeters); // BMI formula
    }
    
    // Method to determine BMI status
    public static string GetBMIStatus(double bmi)
    {
        if (bmi <= 18.4)
            return "Underweight";
        else if (bmi >= 18.5 && bmi <= 24.9)
            return "Normal";
        else if (bmi >= 25.0 && bmi <= 39.9)
            return "Overweight";
        else
            return "Obese";
    }
}
