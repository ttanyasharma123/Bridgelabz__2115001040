using System;
using System.Data.SqlClient;
using System.IO;


class DatabaseToCSV
{
    static void Main()
    {
        string connectionString = "your_connection_string_here"; // Update with your DB connection string
        string query = "SELECT EmployeeID, Name, Department, Salary FROM Employees";
        string csvFilePath = "Employees.csv";


        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                using (StreamWriter writer = new StreamWriter(csvFilePath))
                {
                    // Write headers
                    writer.WriteLine("Employee ID,Name,Department,Salary");


                    // Write data rows
                    while (reader.Read())
                    {
                        string line = $"{reader["EmployeeID"]},{reader["Name"]},{reader["Department"]},{reader["Salary"]}";
                        writer.WriteLine(line);
                    }
                }
            }


            Console.WriteLine($"CSV file generated successfully: {csvFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}




