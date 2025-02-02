using System;

public class HandshakeCalculator
{
    // Method to calculate maximum number of handshakes using combination formula
    public static int CalculateHandshakes(int numberOfStudents)
    {
        // Combination formula to calculate the maximum number of handshakes
        return (numberOfStudents * (numberOfStudents - 1)) / 2;
    }

    public static void Main()
    {
        // Taking input for the number of students
        Console.Write("Enter the number of students: ");
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());

        // Ensure that the number of students is greater than 1 for handshakes to be possible
        if (numberOfStudents < 2)
        {
            Console.WriteLine("At least 2 students are required to have handshakes.");
        }
        else
        {
            // Calling the method to calculate handshakes
            int handshakes = CalculateHandshakes(numberOfStudents);
            // Output the result
            Console.WriteLine("The maximum number of handshakes among {0} students is: {1}", numberOfStudents, handshakes);
        }
    }
}
