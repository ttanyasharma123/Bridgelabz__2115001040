using System;
using System.IO;


class CSVWriter
{
    static void Main()
    {
        string filePath = "employees.csv"; // File to write data


        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Writing the header
                writer.WriteLine("ID,Name,Department,Salary");


                // Writing employee records
                writer.WriteLine("101,Alice,HR,50000");
                writer.WriteLine("102,Bob,IT,60000");
                writer.WriteLine("103,Charlie,Finance,55000");
                writer.WriteLine("104,David,Marketing,58000");
                writer.WriteLine("105,Eve,Operations,62000");
            }


            Console.WriteLine("Employee data successfully written to 'employees.csv'");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}


