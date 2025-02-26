using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        string filePath1 = "file1.json";
        string filePath2 = "file2.json";

        if (File.Exists(filePath1) && File.Exists(filePath2))
        {
            // Read JSON files
            string json1 = File.ReadAllText(filePath1);
            string json2 = File.ReadAllText(filePath2);

            // Parse JSON into JObject
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

            // Save merged JSON to a new file
            File.WriteAllText("merged.json", obj1.ToString(Formatting.Indented));
            Console.WriteLine("Merged JSON saved to merged.json");
        }
        else
        {
            Console.WriteLine("One or both files not found!");
        }
    }
}


