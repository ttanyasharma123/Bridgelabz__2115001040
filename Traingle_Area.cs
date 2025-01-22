using System;

class TriangleArea
{
    static void Main()
    {
        
        Console.WriteLine("Enter the base of the triangle in inches:");
        double baseInInches = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the height of the triangle in inches:");
        double heightInInches = Convert.ToDouble(Console.ReadLine());

        
        double areaInInches = 0.5 * baseInInches * heightInInches;

        
        double areaInCm = areaInInches * (2.54 * 2.54);

        
        Console.WriteLine("The area of the triangle in square inches is: " + areaInInches);
        Console.WriteLine("The area of the triangle in square centimeters is: " + areaInCm);
    }
}


