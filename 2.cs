using System;

// Base class: Employee
class Employee
{
    public string Name { get; set; }
    public int Id { get; set; }
    public double Salary { get; set; }

    public Employee(string name, int id, double salary)
    {
        Name = name;
        Id = id;
        Salary = salary;
    }

    // Virtual method to be overridden by subclasses
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}, ID: {Id}, Salary: {Salary}");
    }
}

// Subclass: Manager
class Manager : Employee
{
    public int TeamSize { get; set; }

    public Manager(string name, int id, double salary, int teamSize) : base(name, id, salary)
    {
        TeamSize = teamSize;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Team Size: {TeamSize}");
    }
}

// Subclass: Developer
class Developer : Employee
{
    public string ProgrammingLanguage { get; set; }

    public Developer(string name, int id, double salary, string programmingLanguage) : base(name, id, salary)
    {
        ProgrammingLanguage = programmingLanguage;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Programming Language: {ProgrammingLanguage}");
    }
}

// Subclass: Intern
class Intern : Employee
{
    public string InternshipDuration { get; set; }

    public Intern(string name, int id, double salary, string internshipDuration) : base(name, id, salary)
    {
        InternshipDuration = internshipDuration;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Internship Duration: {InternshipDuration}");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Employee manager = new Manager("Abhi", 101, 75000, 5);
        Employee developer = new Developer("Bobby", 102, 60000, "C#");
        Employee intern = new Intern("Chetan", 103, 20000, "3 months");

        manager.DisplayDetails();
        Console.WriteLine();
        developer.DisplayDetails();
        Console.WriteLine();
        intern.DisplayDetails();
    }
}
