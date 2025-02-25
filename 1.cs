using System;
using System.IO;


class CSVReader
{
    static void Main()
    {
        string filePath = "students.csv";  // Ensure the file exists in the same directory as the executable


        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isHeader = true;


                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader)  // Skip the header row
                    {
                        isHeader = false;
                        continue;
                    }


                    string[] data = line.Split(',');


                    Console.WriteLine($"ID: {data[0]}, Name: {data[1]}, Age: {data[2]}, Marks: {data[3]}");
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: File not found. Please ensure 'students.csv' exists in the correct directory.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
