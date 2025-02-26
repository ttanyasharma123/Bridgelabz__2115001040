using System;
using System.Collections.Generic;
using Newtonsoft.Json; 

class Person
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        // Create a list of Person objects
        List<Person> people = new List<Person>
        {
            new Person { Name = "Tanya Sharma", Email = "tanya@example.com", Age = 22 },
            new Person { Name = "Amit Verma", Email = "amit@example.com", Age = 28 },
            new Person { Name = "Priya Mehta", Email = "priya@example.com", Age = 24 }
        };

        // Convert the list into a JSON array
        string jsonArray = JsonConvert.SerializeObject(people, Formatting.Indented);

        // Print the JSON output
        Console.WriteLine("JSON Array:");
        Console.WriteLine(jsonArray);
    }
}

