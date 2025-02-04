using System;

class Student
{
    // Static variable shared by all students
    public static string UniversityName = "Gla University";

    // Static variable to keep track of the total number of students
    private static int totalStudents = 0;

    // Readonly variable for Roll Number (cannot be changed after assignment)
    public readonly int RollNumber;

    // Instance variables
    public string Name { get; private set; }
    public string Grade { get; private set; }

    // Constructor using 'this' to initialize variables
    public Student(int rollNumber, string name, string grade)
    {
        this.RollNumber = rollNumber;
        this.Name = name;
        this.Grade = grade;

        // Increment total student count
        totalStudents++;
    }

    // Static method to display total number of students
    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students Enrolled: " + totalStudents);
    }

    // Method to display student details, using 'is' operator
    public void DisplayStudentDetails()
    {
        if (this is Student)
        {
            Console.WriteLine("Roll Number: " + RollNumber);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Grade: " + Grade);
            Console.WriteLine("University: " + UniversityName);
            Console.WriteLine("--------------------------");
        }
    }

    // Method to update student grade (if the object is a Student instance)
    public void UpdateGrade(string newGrade)
    {
        if (this is Student)
        {
            this.Grade = newGrade;
            Console.WriteLine("Grade updated for Roll Number " + RollNumber + " to " + newGrade);
        }
    }

    // Destructor to decrement student count when an object is destroyed
    ~Student()
    {
        totalStudents--;
    }
}

// Main class to test the Student class
class Program
{
    static void Main()
    {
        // Creating Student objects
        Student student1 = new Student(101, "Akash", "A");
        Student student2 = new Student(102, "Deepak", "B");

        // Displaying student details
        student1.DisplayStudentDetails();
        student2.DisplayStudentDetails();

        // Display total students
        Student.DisplayTotalStudents();

        // Updating a student's grade
        student2.UpdateGrade("A+");

        // Display student details again after update
        student2.DisplayStudentDetails();
    }
}
