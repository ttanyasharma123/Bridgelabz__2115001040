using System;

// Base class: Person
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void DisplayRole()
    {
        Console.WriteLine("This is a general person.");
    }
}

// Subclass: Teacher
class Teacher : Person
{
    public string Subject { get; set; }

    public Teacher(string name, int age, string subject)
        : base(name, age)
    {
        Subject = subject;
    }

    public override void DisplayRole()
    {
        Console.WriteLine($"{Name} is a Teacher who teaches {Subject}.");
    }
}

// Subclass: Student
class Student : Person
{
    public string Grade { get; set; }

    public Student(string name, int age, string grade)
        : base(name, age)
    {
        Grade = grade;
    }

    public override void DisplayRole()
    {
        Console.WriteLine($"{Name} is a Student in grade {Grade}.");
    }
}

// Subclass: Staff
class Staff : Person
{
    public string Department { get; set; }

    public Staff(string name, int age, string department)
        : base(name, age)
    {
        Department = department;
    }

    public override void DisplayRole()
    {
        Console.WriteLine($"{Name} is a Staff member in the {Department} department.");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Teacher teacher = new Teacher("Alice", 35, "Mathematics");
        Student student = new Student("Bob", 16, "10th Grade");
        Staff staff = new Staff("Charlie", 40, "Administration");

        teacher.DisplayRole();
        student.DisplayRole();
        staff.DisplayRole();
    }
}
