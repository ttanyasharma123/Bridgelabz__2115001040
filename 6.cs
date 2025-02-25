

using System;
using System.IO;
using System.Globalization;


class CSVUpdater
{
    static void Main()
    {
        string inputFilePath = "employees.csv";   // Original file
        string outputFilePath = "updated_employees.csv"; // New file with updated salaries


        try
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string line;
                bool isHeader = true;


                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader) // Write the header as it is
                    {
                        writer.WriteLine(line);
                        isHeader = false;
                        continue;
                    }


                    string[] data = line.Split(',');


                    // Check if the department is "IT"
                    if (data[2].Trim().Equals("IT", StringComparison.OrdinalIgnoreCase))
                    {
                        double salary = double.Parse(data[3], CultureInfo.InvariantCulture);
                        salary *= 1.10; // Increase by 10%
                        data[3] = salary.ToString("F2"); // Format to 2 decimal places
                    }


                    // Write updated record to new file
                    writer.WriteLine(string.Join(",", data));
                }
            }


            Console.WriteLine("Updated salaries saved in 'updated_employees.csv'");
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


