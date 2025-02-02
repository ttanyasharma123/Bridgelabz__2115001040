using System;

public class SimpleInterestCalculator
{
    // Method to calculate Simple Interest
    public static double CalculateSimpleInterest(double principal, double rateOfInterest, double timeInYears)
    {
        return (principal * rateOfInterest * timeInYears) / 100;
    }

    public static void Main()
    {
        // Declare variables with proper naming conventions
        double principalAmount, rateOfInterest, timeInYears, simpleInterest;

        // Taking user input for Principal, Rate of Interest, and Time
        Console.Write("Enter the Principal Amount: ");
        principalAmount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the Rate of Interest: ");
        rateOfInterest = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the Time in years: ");
        timeInYears = Convert.ToDouble(Console.ReadLine());

        // Calling the method to calculate Simple Interest
        simpleInterest = CalculateSimpleInterest(principalAmount, rateOfInterest, timeInYears);

        // Displaying the result using string.Format() to avoid $ syntax
        Console.WriteLine(string.Format("\nThe Simple Interest is {0} for Principal {1}, Rate of Interest {2}, and Time {3} years.", 
                        simpleInterest, principalAmount, rateOfInterest, timeInYears));
    }
}
