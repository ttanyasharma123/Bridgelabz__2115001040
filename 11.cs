using System;
using System.IO;
using System.Collections.Generic;


class LargeCSVReader
{
    static void Main()
    {
        string filePath = "large_file.csv"; // Ensure this file exists


        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isHeader = true;
                int batchSize = 100; // Process 100 lines at a time
                int totalRecords = 0;


                List<string> batch = new List<string>();


                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader) // Skip the header row
                    {
                        isHeader = false;
                        continue;
                    }


                    batch.Add(line);
                    totalRecords++;


                    // Process the batch after every 100 lines
                    if (batch.Count == batchSize)
                    {
                        ProcessBatch(batch);
                        batch.Clear(); // Clear the batch after processing
                    }
                }


                // Process remaining lines if any
                if (batch.Count > 0)
                {
                    ProcessBatch(batch);
                }


                Console.WriteLine($"Total records processed: {totalRecords}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: File not found. Please ensure 'large_file.csv' exists.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }


    static void ProcessBatch(List<string> batch)
    {
        Console.WriteLine($"Processing {batch.Count} records...");
        // Simulate processing (e.g., storing in a database)
    }
}
