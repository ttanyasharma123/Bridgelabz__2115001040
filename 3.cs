using System;
using System.Collections.Generic;

class Company
{
    public string CompanyName { get; set; }
    public List<Department> Departments { get; set; }

    public Company(string name)
    {
        CompanyName = name;
        Departments = new List<Department>();
    }

    // Add a department to the company
    public void AddDepartment(Department department)
    {
        Departments.Add(department);
    }

    // Deleting a company will also delete all departments and employees
    public void DeleteCompany()
    {
        Departments.Clear(); // Removes all departments and employees
        Console.WriteLine("Company " + CompanyName + " has been deleted.");
    }
}

class Department
{
    public string DepartmentName { get; set; }
    public List<Employee> Employees { get; set; }

    public Department(string name)
    {
        DepartmentName = name;
        Employees = new List<Employee>();
    }

    // Add an employee to the department
    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }
}

class Employee
{
    public string EmployeeName { get; set; }

    public Employee(string name)
    {
        EmployeeName = name;
    }
}

class Program
{
    static void Main()
    {
        // Create a company
        Company company = new Company("TechMahindra ");

        // Create departments
        Department dept1 = new Department("HR");
        Department dept2 = new Department("IT");

        // Create employees
        Employee emp1 = new Employee("Aditya");
        Employee emp2 = new Employee("Raghu");

        // Add employees to departments
        dept1.AddEmployee(emp1);
        dept2.AddEmployee(emp2);

        // Add departments to the company
        company.AddDepartment(dept1);
        company.AddDepartment(dept2);

        // Show company details
        Console.WriteLine("Company: " + company.CompanyName);
        foreach (var dept in company.Departments)
        {
            Console.WriteLine("  Department: " + dept.DepartmentName);
            foreach (var emp in dept.Employees)
            {
                Console.WriteLine("    Employee: " + emp.EmployeeName);
            }
        }

        // Deleting the company will also delete departments and employees
        company.DeleteCompany();
    }
}
