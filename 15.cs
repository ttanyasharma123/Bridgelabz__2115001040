using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.IO;

class Employee
{
    public int EmployeeID { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}

class Program
{
    static void Main()
    {
        string connectionString = "your_connection_string_here"; // Replace with your DB connection string
        string query = "SELECT EmployeeID, Name, Department, Salary FROM Employees";

        List<Employee> employees = new List<Employee>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        EmployeeID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Department = reader.GetString(2),
                        Salary = reader.GetDecimal(3)
                    });
                }
            }
        }

        // Convert list to JSON
        string jsonOutput = JsonConvert.SerializeObject(employees, Formatting.Indented);

        // Print JSON
        Console.WriteLine("Generated JSON Report:");
        Console.WriteLine(jsonOutput);

        // Save JSON to a file
        File.WriteAllText("EmployeeReport.json", jsonOutput);
        Console.WriteLine("JSON report saved as EmployeeReport.json");
    }
}

