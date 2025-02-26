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

            // Parse JSON
            JObject jsonObject = JObject.Parse(jsonData);

            // Print all keys and values
            Console.WriteLine("JSON Keys and Values:");
            PrintJson(jsonObject, 0);
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }

    // Recursive function to print keys and values
    static void PrintJson(JToken token, int indent)
    {
        if (token is JObject obj)
        {
            foreach (var property in obj.Properties())
            {
                Console.WriteLine($"{new string(' ', indent)}{property.Name}:");
                PrintJson(property.Value, indent + 2);
            }
        }
        else if (token is JArray array)
        {
            foreach (var item in array)
            {
                PrintJson(item, indent + 2);
            }
        }
        else
        {
            Console.WriteLine($"{new string(' ', indent)}{token}");
        }
    }
}
