using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        string filePath = "data.json"; // Path to JSON file

        if (File.Exists(filePath))
        {
            // Read JSON file
            string jsonData = File.ReadAllText(filePath);

            // Parse JSON array
            JArray jsonArray = JArray.Parse(jsonData);

            Console.WriteLine("Extracted Data:");

            // Extract specific fields (name, email)
            foreach (JObject obj in jsonArray)
            {
                string name = obj["name"]?.ToString();
                string email = obj["email"]?.ToString();

                Console.WriteLine($"Name: {name}, Email: {email}");
            }
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}


