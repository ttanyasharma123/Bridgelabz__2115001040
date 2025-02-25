using System;
using System.Collections.Generic;
using System.IO;


class CSV_DuplicateChecker
{
    static void Main()
    {
        string filePath = "data.csv"; // Change this to your actual CSV file path


        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: File not found!");
            return;
        }


        Dictionary<string, List<string>> recordMap = new Dictionary<string, List<string>>();
        List<string> duplicateRecords = new List<string>();


        using (StreamReader reader = new StreamReader(filePath))
        {
            string header = reader.ReadLine(); // Read the header row
            Console.WriteLine(header); // Print Header
            string line;


            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(','); // Assuming CSV is comma-separated
                string id = fields[0]; // Assuming ID is in the first column


                if (recordMap.ContainsKey(id))
                {
                    duplicateRecords.Add(line);
                    duplicateRecords.Add(string.Join(",", recordMap[id]));
                }
                else
                {
                    recordMap[id] = new List<string>(fields);
                }
            }
        }


        // Print Duplicate Records
        if (duplicateRecords.Count > 0)
        {
            Console.WriteLine("\nDuplicate Records Found:");
            foreach (var record in duplicateRecords)
            {
                Console.WriteLine(record);
            }
        }
        else
        {
            Console.WriteLine("\nNo duplicate records found.");
        }
    }
}
