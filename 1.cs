using System;
using System.Collections.Generic;

// Create a interface IDepartment
interface IDepartment
{
    void AssignDepartment(string department);
    string GetDepartmentDetails();
}

abstract class Employee
{
    // Encapsulation field
    private int employeeId;
    private string name;
    private double baseSalary;

    // now we are using the properties for encapsulation 
    public int EmployeeId { get => employeeId; set => employeeId = value; }
    public string Name { get => name; set => name = value; }
    public double BaseSalary { get => baseSalary; set => baseSalary = value; }

    // now we are using constructor
    public Employee(int id, string name, double baseSalary)
    {
        this.employeeId = id;
        this.name = name;
        this.baseSalary = baseSalary;
    }

    public abstract double CalculateSalary();

    // create a method to display details
    public void DisplayDetails()
    {
        Console.WriteLine($"ID: {EmployeeId}, Name: {Name}, Salary: {CalculateSalary():C}");
    }
}

// now we are creating full-time employee class
class FullTimeEmployee : Employee, IDepartment
{
    private string department;

    public FullTimeEmployee(int id, string name, double salary) : base(id, name, salary) { }

    public override double CalculateSalary()
    {
        return BaseSalary; // Fixed salary for full-time employees
    }

    public void AssignDepartment(string department)
    {
        this.department = department;
    }

    public string GetDepartmentDetails()
    {
        return $"{Name} works in {department} department.";
    }
}

class PartTimeEmployee : Employee, IDepartment
{
    private double hourlyRate;
    private int hoursWorked;
    private string department;

    public PartTimeEmployee(int id, string name, double hourlyRate, int hoursWorked)
        : base(id, name, 0)
    {
        this.hourlyRate = hourlyRate;
        this.hoursWorked = hoursWorked;
    }

    public override double CalculateSalary()
    {
        return hourlyRate * hoursWorked;
    }

    public void AssignDepartment(string department)
    {
        this.department = department;
    }

    public string GetDepartmentDetails()
    {
        return $"{Name} works in {department} department.";
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        FullTimeEmployee full = new FullTimeEmployee(21, "Shreya", 500000);
        full.AssignDepartment("Software Engineer");

        PartTimeEmployee part = new PartTimeEmployee(22, "Saumya", 500, 45);
        part.AssignDepartment("Data-Scientist");

        employees.Add(full);
        employees.Add(part);

        // Now we are using polymorphism
        foreach (Employee emp in employees)
        {
            emp.DisplayDetails();
        }

        // now we are displaying department details
        Console.WriteLine(full.GetDepartmentDetails());
        Console.WriteLine(part.GetDepartmentDetails());
    }
}
