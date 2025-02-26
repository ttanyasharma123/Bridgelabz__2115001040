using System;
using System.Collections.Generic;
using Newtonsoft.Json; 

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Subjects { get; set; }
}

class Program
{
    static void Main()
    {
        // Creating a Student object
        Student student = new Student
        {
            Name = "Tanya",
            Age = 21,
            Subjects = new List<string> { "Math", "Physics", "Computer Science" }
        };

        // Convert the Student object to JSON
        string jsonString = JsonConvert.SerializeObject(student, Formatting.Indented);
        
        // Print the JSON string
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(jsonString);
    }
}
