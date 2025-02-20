using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "large_log.txt"; // Change this to the actual file path

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine(line); // Print only lines containing "error"
                    }
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
    }
}

