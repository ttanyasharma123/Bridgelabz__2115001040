using System;
using System.Reflection;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student()
    {
        Name = "Default Name";
        Age = 18;
    }

    public void Display()
    {
        Console.WriteLine($"Student Name: {Name}, Age: {Age}");
    }
}

class Program
{
    static void Main()
    {
        // Get the type of the Student class
        Type type = typeof(Student);

        // Create an instance dynamically using Activator.CreateInstance
        object obj = Activator.CreateInstance(type);

        // Cast the object to Student type
        Student student = obj as Student;

        // Check if object is created successfully
        if (student != null)
        {
            // Modify properties dynamically
            student.Name = "Tanya";
            student.Age = 21;

            // Invoke the Display method
            student.Display();
        }
        else
        {
            Console.WriteLine("Failed to create an instance.");
        }
    }
}

