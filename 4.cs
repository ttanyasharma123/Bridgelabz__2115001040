using System;
using System.Collections.Generic;

class School
{
    public string SchoolName { get; set; }
    public List<Student> Students { get; set; }

    public School(string name)
    {
        SchoolName = name;
        Students = new List<Student>(); // Aggregation: School contains students, but students can exist without school
    }

    // Add a student to the school
    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    // Display school details
    public void ShowSchoolDetails()
    {
        Console.WriteLine("School: " + SchoolName);
        foreach (var student in Students)
        {
            student.ShowStudentCourses();
        }
    }
}

class Student
{
    public string StudentName { get; set; }
    public List<Course> EnrolledCourses { get; set; }

    public Student(string name)
    {
        StudentName = name;
        EnrolledCourses = new List<Course>(); 
    }

    // Enroll in a course
    public void EnrollInCourse(Course course)
    {
        EnrolledCourses.Add(course);
        course.EnrolledStudents.Add(this); 
    }

    // Show courses the student is enrolled in
    public void ShowStudentCourses()
    {
        Console.WriteLine("  Student: " + StudentName);
        foreach (var course in EnrolledCourses)
        {
            Console.WriteLine("    Enrolled in: " + course.CourseName);
        }
    }
}

class Course
{
    public string CourseName { get; set; }
    public List<Student> EnrolledStudents { get; set; }

    public Course(string name)
    {
        CourseName = name;
        EnrolledStudents = new List<Student>(); // Many-to-Many relationship: Course has multiple students
    }

    // Show students enrolled in this course
    public void ShowEnrolledStudents()
    {
        Console.WriteLine("Course: " + CourseName);
        foreach (var student in EnrolledStudents)
        {
            Console.WriteLine("  Enrolled Student: " + student.StudentName);
        }
    }
}

class Program
{
    static void Main()
    {
        // Create a school
        School school = new School("Kranti Public School");

        // Create students
        Student student1 = new Student("Suraj");
        Student student2 = new Student("Raaj");

        // Create courses
        Course math = new Course("Mathematics");
        Course science = new Course("Science");

        // Enroll students in courses (Many-to-Many relationship)
        student1.EnrollInCourse(math);
        student1.EnrollInCourse(science);
        student2.EnrollInCourse(math);

        // Add students to the school (Aggregation relationship)
        school.AddStudent(student1);
        school.AddStudent(student2);

        // Display details
        school.ShowSchoolDetails();
        Console.WriteLine();
        math.ShowEnrolledStudents();
        science.ShowEnrolledStudents();
    }
}
