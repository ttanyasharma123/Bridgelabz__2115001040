using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json; 

class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        // JSON Data (Sample Users)
        string json = @"[
            { ""Name"": ""Tanya Sharma"", ""Email"": ""tanya@example.com"", ""Age"": 22 },
            { ""Name"": ""Amit Verma"", ""Email"": ""amit@example.com"", ""Age"": 28 },
            { ""Name"": ""Rahul Singh"", ""Email"": ""rahul@example.com"", ""Age"": 30 },
            { ""Name"": ""Priya Mehta"", ""Email"": ""priya@example.com"", ""Age"": 24 }
        ]";

        // Deserialize JSON into List<User>
        List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

        // Filter users where Age > 25
        var filteredUsers = users.Where(user => user.Age > 25).ToList();

        // Convert filtered list back to JSON
        string filteredJson = JsonConvert.SerializeObject(filteredUsers, Formatting.Indented);

        // Print filtered JSON
        Console.WriteLine("Filtered Users (Age > 25):");
        Console.WriteLine(filteredJson);
    }
}
