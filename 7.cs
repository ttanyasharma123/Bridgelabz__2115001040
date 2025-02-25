using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

class CSVSorter
{
    static void Main()
    {
        string filePath = "employees.csv"; // CSV file to read

        try
        {
            List<string[]> employees = new List<string[]>(); // List to store records
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isHeader = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader) // Store the header separately
                    {
                        isHeader = false;
                        continue;
                    }

                    employees.Add(line.Split(',')); // Add employee record to the list
                }
            }

            // Sort records by Salary (Descending)
            var sortedEmployees = employees.OrderByDescending(e => double.Parse(e[3], CultureInfo.InvariantCulture)).ToList();

            // Print Top 5 highest-paid employees
            Console.WriteLine("Top 5 Highest-Paid Employees:");
            Console.WriteLine("--------------------------------------");

            for (int i = 0; i < Math.Min(5, sortedEmployees.Count); i++)
            {
                Console.WriteLine($"ID: {sortedEmployees[i][0]}, Name: {sortedEmployees[i][1]}, Department: {sortedEmployees[i][2]}, Salary: {sortedEmployees[i][3]}");
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

