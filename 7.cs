using System;

public class StudentVoteChecker
{
    // Method to check if a student can vote based on their age
    public static bool CanStudentVote(int age)
    {
        // Validate if the age is negative
        if (age < 0)
        {
            return false; // Negative age is not valid, cannot vote
        }

        // Check if the age is 18 or above
        if (age >= 18)
        {
            return true; // Can vote if age is 18 or above
        }
        else
        {
            return false; // Cannot vote if age is below 18
        }
    }

    // Main method to take input for 10 students and display if they can vote
    public static void Main()
    {
        int[] studentAges = new int[10]; // Array to store ages of 10 students
        Console.WriteLine("Please enter the age of 10 students:");

        // Loop through the array to take input for each student's age
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Enter age for student " + (i + 1) + ": ");
            // Take the input and store it in the array
            studentAges[i] = Convert.ToInt32(Console.ReadLine());

            // Check if the student can vote and display the result
            if (CanStudentVote(studentAges[i]))
            {
                Console.WriteLine("Student " + (i + 1) + " can vote.");
            }
            else
            {
                Console.WriteLine("Student " + (i + 1) + " cannot vote.");
            }
        }
    }
}
