using System;

class HandshakeCalculator
{
    // Main method
    static void Main(string[] args)
    {
        // Get the number of students from the user
        Console.Write("Enter the number of students: ");
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());

        // Calculate the maximum number of handshakes using the formula
        int totalHandshakes = CalculateHandshakes(numberOfStudents);

        // Display the result using string.Format() instead of string interpolation
        Console.WriteLine(string.Format("The maximum number of handshakes possible among {0} students is: {1}", numberOfStudents, totalHandshakes));
    }

    // Method to calculate the total number of handshakes
    static int CalculateHandshakes(int numberOfStudents)
    {
        // Formula to calculate combinations: (n * (n - 1)) / 2
        return (numberOfStudents * (numberOfStudents - 1)) / 2;
    }
}
