using System;
using System.IO;

class FileReading
{
    static void Main()
    {
        string filePath = "info.txt"; // File name

        try
        {
            // Using statement ensures StreamReader is closed automatically
            using (StreamReader reader = new StreamReader(filePath))
            {
                string firstLine = reader.ReadLine();
                Console.WriteLine($"First line: {firstLine}");
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Error reading file.");
        }
    }
}

