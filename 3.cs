

using System;
using System.IO;


class CSVRowCounter
{
    static void Main()
    {
        string filePath = "employees.csv"; // File to read


        try
        {
            int recordCount = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read the first line (header) and ignore it
                if (!reader.EndOfStream)
                {
                    reader.ReadLine();
                }


                // Read each record and count
                while (reader.ReadLine() != null)
                {
                    recordCount++;
                }
            }


            Console.WriteLine($"Total number of records (excluding header): {recordCount}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: File not found. Please ensure 'employees.csv' exists.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}


