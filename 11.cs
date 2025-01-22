using System;

class SimpleInterestCalculator
{
    static void Main()
    {
        
        double principal, rate, time, simpleInterest;

        
        Console.Write("Enter the principal amount: ");
        principal = double.Parse(Console.ReadLine());

        Console.Write("Enter the rate of interest: ");
        rate = double.Parse(Console.ReadLine());

        Console.Write("Enter the time (in years): ");
        time = double.Parse(Console.ReadLine());

       
        simpleInterest = (principal * rate * time) / 100;

        
        Console.WriteLine("The Simple Interest is {0} for Principal {1}, Rate of Interest {2} and Time {3} years.", simpleInterest, principal, rate, time);
    }
}
