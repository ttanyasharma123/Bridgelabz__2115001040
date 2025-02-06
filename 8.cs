using System;
using System.Collections.Generic;

class Course
{
    public string CourseName { get; set; }
    public Professor AssignedProfessor { get; private set; } // Aggregation: Course has a professor, but professor exists independently
    public List<Student> EnrolledStudents { get; set; }

    public Course(string name)
    {
        CourseName = name;
        EnrolledStudents = new List<Student>();
    }

    // Assign a professor to the course
    public void AssignProfessor(Professor professor)
    {
        AssignedProfessor = professor;
        professor.TeachCourse(this);
        Console.WriteLine("Professor " + professor.ProfessorName + " is now teaching " + CourseName);
    }

    // Enroll a student in the course
    public void EnrollStudent(Student student)
    {
        EnrolledStudents.Add(student);
        student.EnrollInCourse(this);
        Console.WriteLine("Student " + student.StudentName + " has enrolled in " + CourseName);
    }

    // Show course details
    public void ShowCourseDetails()
    {
        Console.WriteLine("\nCourse: " + CourseName);
        Console.WriteLine("Taught by: " + (AssignedProfessor != null ? AssignedProfessor.ProfessorName : "No Professor Assigned"));
        Console.WriteLine("Enrolled Students:");
        foreach (var student in EnrolledStudents)
        {
            Console.WriteLine("  - " + student.StudentName);
        }
    }
}

class Professor
{
    public string ProfessorName { get; set; }
    public List<Course> CoursesTaught { get; set; }

    public Professor(string name)
    {
        ProfessorName = name;
        CoursesTaught = new List<Course>(); // Aggregation: A professor can teach multiple courses
    }

    // Teach a course
    public void TeachCourse(Course course)
    {
        if (!CoursesTaught.Contains(course))
        {
            CoursesTaught.Add(course);
        }
    }

    // Show courses taught by the professor
    public void ShowCourses()
    {
        Console.WriteLine("\nProfessor " + ProfessorName + " teaches:");
        foreach (var course in CoursesTaught)
        {
            Console.WriteLine("  - " + course.CourseName);
        }
    }
}

class Student
{
    public string StudentName { get; set; }
    public List<Course> CoursesEnrolled { get; set; }

    public Student(string name)
    {
        StudentName = name;
        CoursesEnrolled = new List<Course>(); // Association: Student can enroll in multiple courses
    }

    // Enroll in a course
    public void EnrollInCourse(Course course)
    {
        if (!CoursesEnrolled.Contains(course))
        {
            CoursesEnrolled.Add(course);
        }
    }

    // Show courses the student is enrolled in
    public void ShowEnrolledCourses()
    {
        Console.WriteLine("\nStudent " + StudentName + " is enrolled in:");
        foreach (var course in CoursesEnrolled)
        {
            Console.WriteLine("  - " + course.CourseName);
        }
    }
}

class Program
{
    static void Main()
    {
        // Create professors
        Professor prof1 = new Professor("Dr. Raman");
        Professor prof2 = new Professor("Dr. Sajay");

        // Create students
        Student student1 = new Student("Aman");
        Student student2 = new Student("Rahul");

        // Create courses
        Course course1 = new Course("Computer Science");
        Course course2 = new Course("Mathematics");

        // Assign professors to courses (Aggregation)
        course1.AssignProfessor(prof1);
        course2.AssignProfessor(prof2);

        // Students enrolling in courses (Association)
        course1.EnrollStudent(student1);
        course1.EnrollStudent(student2);
        course2.EnrollStudent(student1);

        // Show details
        prof1.ShowCourses();
        prof2.ShowCourses();

        student1.ShowEnrolledCourses();
        student2.ShowEnrolledCourses();

        course1.ShowCourseDetails();
        course2.ShowCourseDetails();
    }
}
