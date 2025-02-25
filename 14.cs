

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;


class JsonCsvConverter
{
    static void Main()
    {
        string jsonFilePath = "students.json";
        string csvFilePath = "students.csv";
        string outputJsonFilePath = "students_converted.json";


        // Convert JSON to CSV
        ConvertJsonToCsv(jsonFilePath, csvFilePath);


        // Convert CSV back to JSON
        ConvertCsvToJson(csvFilePath, outputJsonFilePath);
    }


    static void ConvertJsonToCsv(string jsonFilePath, string csvFilePath)
    {
        if (!File.Exists(jsonFilePath))
        {
            Console.WriteLine("Error: JSON file not found!");
            return;
        }


        string jsonData = File.ReadAllText(jsonFilePath);
        var students = JsonConvert.DeserializeObject<List<Student>>(jsonData);


        using (StreamWriter writer = new StreamWriter(csvFilePath))
        {
            // Write CSV Header
            writer.WriteLine("ID,Name,Age,Marks");


            // Write CSV Rows
            foreach (var student in students)
            {
                writer.WriteLine($"{student.ID},{student.Name},{student.Age},{student.Marks}");
            }
        }


        Console.WriteLine($"CSV file generated successfully: {csvFilePath}");
    }


    static void ConvertCsvToJson(string csvFilePath, string jsonFilePath)
    {
        if (!File.Exists(csvFilePath))
        {
            Console.WriteLine("Error: CSV file not found!");
            return;
        }


        var students = new List<Student>();
        var lines = File.ReadAllLines(csvFilePath).Skip(1); // Skip header


        foreach (var line in lines)
        {
            var fields = line.Split(',');
            students.Add(new Student
            {
                ID = int.Parse(fields[0]),
                Name = fields[1],
                Age = int.Parse(fields[2]),
                Marks = int.Parse(fields[3])
            });
        }


        string jsonOutput = JsonConvert.SerializeObject(students, Formatting.Indented);
        File.WriteAllText(jsonFilePath, jsonOutput);


        Console.WriteLine($"JSON file generated successfully: {jsonFilePath}");
    }
}


// Student Class
class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
}




