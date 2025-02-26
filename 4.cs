using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        // First JSON object
        string json1 = @"{
            ""name"": ""Tanya Sharma"",
            ""email"": ""tanya@example.com"",
            ""age"": 22
        }";

        // Second JSON object
        string json2 = @"{
            ""city"": ""Delhi"",
            ""phone"": ""9876543210"",
            ""email"": ""new_email@example.com""  // This will overwrite the previous email
        }";

        // Parse the JSON strings into JObject
        JObject obj1 = JObject.Parse(json1);
        JObject obj2 = JObject.Parse(json2);

        // Merge obj2 into obj1
        obj1.Merge(obj2, new JsonMergeSettings
        {
            MergeArrayHandling = MergeArrayHandling.Union // Ensures arrays are combined instead of replaced
        });

        // Print merged JSON
        Console.WriteLine("Merged JSON:");
        Console.WriteLine(obj1.ToString(Formatting.Indented));
    }
}

