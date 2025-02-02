using System;

namespace CollinearPoints
{
    class Program
    {
        // Method to check if three points are collinear using the slope formula
        public static bool ArePointsCollinearBySlope(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            // Calculate slope of AB and BC
            double slopeAB = (y2 - y1) / (x2 - x1);
            double slopeBC = (y3 - y2) / (x3 - x2);

            // Check if slopes are equal, if yes, the points are collinear
            return slopeAB == slopeBC;
        }

        // Method to check if three points are collinear using the area of triangle formula
        public static bool ArePointsCollinearByArea(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            // Calculate the area of the triangle using the formula
            double area = 0.5 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));

            // If area is 0, points are collinear
            return area == 0;
        }

        static void Main(string[] args)
        {
            // Taking inputs for 3 points A(x1, y1), B(x2, y2), C(x3, y3)
            Console.WriteLine("Enter the coordinates of point A (x1, y1):");
            Console.Write("x1: ");
            double x1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("y1: ");
            double y1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the coordinates of point B (x2, y2):");
            Console.Write("x2: ");
            double x2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("y2: ");
            double y2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the coordinates of point C (x3, y3):");
            Console.Write("x3: ");
            double x3 = Convert.ToDouble(Console.ReadLine());
            Console.Write("y3: ");
            double y3 = Convert.ToDouble(Console.ReadLine());

            // Check if the points are collinear by slope
            bool areCollinearBySlope = ArePointsCollinearBySlope(x1, y1, x2, y2, x3, y3);
            Console.WriteLine("Are the points collinear using the slope formula? " + (areCollinearBySlope ? "Yes" : "No"));

            // Check if the points are collinear by area
            bool areCollinearByArea = ArePointsCollinearByArea(x1, y1, x2, y2, x3, y3);
            Console.WriteLine("Are the points collinear using the area formula? " + (areCollinearByArea ? "Yes" : "No"));
        }
    }
}
