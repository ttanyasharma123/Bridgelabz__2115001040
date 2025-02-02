using System;

class Quadratic
{
    // Method to find the roots of the quadratic equation
    public static void FindRoots(double a, double b, double c)
    {
        // Calculate delta (discriminant)
        double delta = (b * b) - (4 * a * c);

        if (delta > 0)
        {
            // Two real and distinct roots
            double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double root2 = (-b - Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine("The roots are real and distinct: root1 = {0}, root2 = {1}", root1, root2);
        }
        else if (delta == 0)
        {
            // One real root
            double root = -b / (2 * a);
            Console.WriteLine("There is one real root: root = {0}", root);
        }
        else
        {
            // No real roots
            Console.WriteLine("There are no real roots (Delta is negative).");
        }
    }

    static void Main()
    {
        // Take input from the user
        Console.WriteLine("Enter the value of a, b, and c for the quadratic equation ax^2 + bx + c = 0:");

        Console.Write("Enter a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        // Call the FindRoots method to calculate the roots
        FindRoots(a, b, c);
    }
}
