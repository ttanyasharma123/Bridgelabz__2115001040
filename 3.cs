using System;
using System.Collections.Generic;

// Step 1: Define CourseType (Abstract Class)
abstract class CourseType
{
    public string EvaluationMethod { get; set; }

    protected CourseType(string method)
    {
        EvaluationMethod = method;
    }

    public abstract void DisplayEvaluationMethod();
}

// Step 2: Define Specific Course Types
class ExamCourse : CourseType
{
    public ExamCourse() : base("Exam-Based Evaluation") { }

    public override void DisplayEvaluationMethod()
    {
        Console.WriteLine("This course is evaluated through exams.");
    }
}

class AssignmentCourse : CourseType
{
    public AssignmentCourse() : base("Assignment-Based Evaluation") { }

    public override void DisplayEvaluationMethod()
    {
        Console.WriteLine("This course is evaluated through assignments.");
    }
}

// Step 3: Create Generic Course Class
class Course<T> where T : CourseType
{
    public int CourseID { get; set; }
    public string CourseName { get; set; }
    public int Credits { get; set; }
    public T CourseEvaluation { get; set; }

    public Course(int id, string name, int credits, T evaluation)
    {
        CourseID = id;
        CourseName = name;
        Credits = credits;
        CourseEvaluation = evaluation;
    }

    public void Display()
    {
        Console.WriteLine($"[Course ID: {CourseID}] {CourseName} ({Credits} Credits) - {CourseEvaluation.EvaluationMethod}");
        CourseEvaluation.DisplayEvaluationMethod();
    }
}

// Step 4: Define Department Class to Manage Courses
class Department
{
    private List<object> courses = new List<object>(); // Using object for flexibility

    public void AddCourse<T>(Course<T> course) where T : CourseType
    {
        courses.Add(course);
        Console.WriteLine($"{course.CourseName} added to the department.");
    }

    public void DisplayCourses()
    {
        Console.WriteLine("\nAvailable Courses:");
        foreach (var course in courses)
        {
            if (course is Course<ExamCourse> examCourse)
                examCourse.Display();
            else if (course is Course<AssignmentCourse> assignmentCourse)
                assignmentCourse.Display();
        }
    }
}

// Step 5: Test the Implementation
class Program
{
    static void Main()
    {
        // Creating Course Types
        ExamCourse examCourseType = new ExamCourse();
        AssignmentCourse assignmentCourseType = new AssignmentCourse();

        // Creating Courses
        Course<ExamCourse> mathCourse = new Course<ExamCourse>(101, "Mathematics", 3, examCourseType);
        Course<AssignmentCourse> csCourse = new Course<AssignmentCourse>(102, "Computer Science", 4, assignmentCourseType);

        // Creating Department and Adding Courses
        Department csDepartment = new Department();
        csDepartment.AddCourse(mathCourse);
        csDepartment.AddCourse(csCourse);

        // Display Courses
        csDepartment.DisplayCourses();
    }
}
