using System;

class GradeCalculator
{
    static void Main()
    {
        Console.Write("Enter marks for Physics: ");
        int physics = int.Parse(Console.ReadLine());

        Console.Write("Enter marks for Chemistry: ");
        int chemistry = int.Parse(Console.ReadLine());

        Console.Write("Enter marks for Maths: ");
        int maths = int.Parse(Console.ReadLine());

        double average = (physics + chemistry + maths) / 3.0;

        string grade;
        string remarks;

        if (average >= 80)
        {
            grade = "A";
            remarks = "(Level 4, above agency-normalized standards)";
        }
        else if (average >= 70)
        {
            grade = "B";
            remarks = "(Level 3, at agency-normalized standards)";
        }
        else if (average >= 60)
        {
            grade = "C";
            remarks = "(Level 2, below, but approaching agency-normalized standards)";
        }
        else if (average >= 50)
        {
            grade = "D";
            remarks = "(Level 1, well below agency-normalized standards)";
        }
        else if (average >= 40)
        {
            grade = "E";
            remarks = "(Level 1-, too below agency-normalized standards)";
        }
        else
        {
            grade = "R";
            remarks = "(Remedial standards)";
        }

        Console.WriteLine($"\nAverage Marks: {average:F2}");
        Console.WriteLine($"Grade: {grade}");
        Console.WriteLine($"Remarks: {remarks}");
    }
}
