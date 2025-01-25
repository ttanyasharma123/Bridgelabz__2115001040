using System;

class GradeCalculator
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of students: ");
        int numberOfStudents = int.Parse(Console.ReadLine());

        int[,] marks = new int[numberOfStudents, 3];
        double[] percentages = new double[numberOfStudents];
        string[] grades = new string[numberOfStudents];

        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine("Enter marks for Student " + (i + 1) + ":");

            for (int j = 0; j < 3; j++)
            {
                string subject = j == 0 ? "Physics" : j == 1 ? "Chemistry" : "Maths";
                do
                {
                    Console.Write(subject + ": ");
                    marks[i, j] = int.Parse(Console.ReadLine());
                    if (marks[i, j] < 0 || marks[i, j] > 100)
                        Console.WriteLine("Invalid input. Marks must be between 0 and 100. Please re-enter.");
                } while (marks[i, j] < 0 || marks[i, j] > 100);
            }

            int totalMarks = marks[i, 0] + marks[i, 1] + marks[i, 2];
            percentages[i] = totalMarks / 3.0;

            if (percentages[i] >= 80)
                grades[i] = "A (Level 4, above agency-normalized standards)";
            else if (percentages[i] >= 70)
                grades[i] = "B (Level 3, at agency-normalized standards)";
            else if (percentages[i] >= 60)
                grades[i] = "C (Level 2, below, but approaching agency-normalized standards)";
            else if (percentages[i] >= 50)
                grades[i] = "D (Level 1, well below agency-normalized standards)";
            else if (percentages[i] >= 40)
                grades[i] = "E (Level 1-, too below agency-normalized standards)";
            else
                grades[i] = "R (Remedial standards)";
        }

        Console.WriteLine("\nResults:");
        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine("Student " + (i + 1) + ":");
            Console.WriteLine("Physics: " + marks[i, 0] + ", Chemistry: " + marks[i, 1] + ", Maths: " + marks[i, 2]);
            Console.WriteLine("Percentage: " + percentages[i].ToString("0.00") + "%");
            Console.WriteLine("Grade: " + grades[i]);
            Console.WriteLine();
        }
    }
}
