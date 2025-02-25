using System;
using System.IO;


class CSVFilter
{
    static void Main()
    {
        string filePath = "students.csv"; // File to read


        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isHeader = true;


                Console.WriteLine("Students who scored more than 80 marks:");


                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader) // Skip the header row
                    {
                        isHeader = false;
                        continue;
                    }


                    string[] data = line.Split(',');
                    int marks = int.Parse(data[3]); // Convert marks to integer


                    if (marks > 80)
                    {
                        Console.WriteLine($"ID: {data[0]}, Name: {data[1]}, Age: {data[2]}, Marks: {data[3]}");
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: File not found. Please ensure 'students.csv' exists.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}


