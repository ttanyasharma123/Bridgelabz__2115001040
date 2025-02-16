using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\tanya\Documents\sample.txt"; // Update this path as needed

        if (File.Exists(filePath))
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
            }
        }
        else
        {
            Console.WriteLine("Error: File not found at " + filePath);
        }
    }
}
