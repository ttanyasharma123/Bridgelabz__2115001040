using System;
using System.Collections.Generic;
using System.Linq;
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
        // JSON Array (Sample Data)
        string json = @"[
            { ""Name"": ""Tanya Sharma"", ""Email"": ""tanya@example.com"", ""Age"": 22 },
            { ""Name"": ""Amit Verma"", ""Email"": ""amit@example.com"", ""Age"": 28 },
            { ""Name"": ""Rahul Singh"", ""Email"": ""rahul@example.com"", ""Age"": 30 },
            { ""Name"": ""Priya Mehta"", ""Email"": ""priya@example.com"", ""Age"": 24 }
        ]";

        // Deserialize JSON into List<Person>
        List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json);

        // Filter records where Age > 25
        var filteredPeople = people.Where(p => p.Age > 25).ToList();

        // Convert filtered list back to JSON
        string filteredJson = JsonConvert.SerializeObject(filteredPeople, Formatting.Indented);

        // Print filtered JSON
        Console.WriteLine("Filtered JSON (Age > 25):");
        Console.WriteLine(filteredJson);
    }
}


