using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "path_to_your_large_file.txt";
        
        // Start timing
        var startTime = DateTime.Now;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Read the file line by line
            }
        }

        var endTime = DateTime.Now;
        Console.WriteLine("StreamReader reading time: " + (endTime - startTime).TotalSeconds + " seconds");
    }
}
