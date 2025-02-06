using System;
using System.Collections.Generic;

class University
{
    public string UniversityName { get; set; }
    public List<Department> Departments { get; set; } // Composition: University owns Departments
    public List<Faculty> FacultyMembers { get; set; } // Aggregation: University has Faculty, but they can exist independently

    public University(string name)
    {
        UniversityName = name;
        Departments = new List<Department>();
        FacultyMembers = new List<Faculty>();
    }

    // Add a department (Composition)
    public void AddDepartment(Department department)
    {
        Departments.Add(department);
    }

    // Add a faculty member (Aggregation)
    public void AddFaculty(Faculty faculty)
    {
        FacultyMembers.Add(faculty);
    }

    // Delete the University (Composition effect: deleting all departments)
    public void DeleteUniversity()
    {
        Departments.Clear(); // Deleting university removes all departments (Composition)
        Console.WriteLine("University " + UniversityName + " has been deleted along with all departments.");
    }

    // Show university details
    public void ShowUniversityDetails()
    {
        Console.WriteLine("University: " + UniversityName);

        Console.WriteLine("  Departments:");
        foreach (var dept in Departments)
        {
            Console.WriteLine("    " + dept.DepartmentName);
        }

        Console.WriteLine("  Faculty Members:");
        foreach (var faculty in FacultyMembers)
        {
            Console.WriteLine("    " + faculty.FacultyName);
        }
    }
}

class Department
{
    public string DepartmentName { get; set; }

    public Department(string name)
    {
        DepartmentName = name;
    }
}

class Faculty
{
    public string FacultyName { get; set; }

    public Faculty(string name)
    {
        FacultyName = name;
    }
}

class Program
{
    static void Main()
    {
        // Create a university
        University university = new University("GLA University");

        // Create departments (Composition: departments belong to university)
        Department dept1 = new Department("Computer Science");
        Department dept2 = new Department("Physics");

        // Create faculty members (Aggregation: faculty can exist independently)
        Faculty faculty1 = new Faculty("Dr.Sanjeev Mehta");
        Faculty faculty2 = new Faculty("Prof. Mayank  Goyal");

        // Add departments to university
        university.AddDepartment(dept1);
        university.AddDepartment(dept2);

        // Add faculty members to university
        university.AddFaculty(faculty1);
        university.AddFaculty(faculty2);

        // Show university details
        university.ShowUniversityDetails();

        // Deleting university (removes departments but not faculty members)
        university.DeleteUniversity();
    }
}
