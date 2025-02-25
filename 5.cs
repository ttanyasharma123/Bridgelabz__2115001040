

using System;
using System.IO;


class CSVSearch
{
    static void Main()
    {
        string filePath = "employees.csv"; // File to read


        Console.Write("Enter employee name to search: ");
        string searchName = Console.ReadLine().Trim(); // Get user input and remove extra spaces


        bool found = false;


        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isHeader = true;


                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader) // Skip the header row
                    {
                        isHeader = false;
                        continue;
                    }


                    string[] data = line.Split(',');


                    if (data[1].Equals(searchName, StringComparison.OrdinalIgnoreCase)) // Case-insensitive match
                    {
                        Console.WriteLine($"Department: {data[2]}, Salary: {data[3]}");
                        found = true;
                        break;
                    }
                }
            }


            if (!found)
            {
                Console.WriteLine("Employee not found.");
            }
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








