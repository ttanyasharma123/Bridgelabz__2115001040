using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; // For JSON Serialization

// Employee class
[Serializable] // Mark as serializable (not needed for JSON but good practice)
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

class EmployeeSerialization
{
    static string filePath = @"C:\Users\tanya\Desktop\employees.json"; // File location

    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
            new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 60000 },
            new Employee { Id = 3, Name = "Charlie", Department = "Finance", Salary = 55000 }
        };

        try
        {
            // Serialize employee list to JSON file
            SerializeEmployees(employees);
            Console.WriteLine("Employees saved successfully!");

            // Deserialize and display employees
            List<Employee> retrievedEmployees = DeserializeEmployees();
            Console.WriteLine("\nRetrieved Employees:");
            foreach (var emp in retrievedEmployees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    // Serialize employee list to file
    static void SerializeEmployees(List<Employee> employees)
    {
        string jsonString = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonString);
    }

    // Deserialize employee list from file
    static List<Employee> DeserializeEmployees()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No data file found. Returning an empty list.");
            return new List<Employee>();
        }

        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Employee>>(jsonString);
    }
}



