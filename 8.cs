using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;


class CSVValidator
{
    static void Main()
    {
        string filePath = "employees.csv"; // Ensure this file exists


        // Regular expressions for validation
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Basic email format check
        string phonePattern = @"^\d{10}$"; // Exactly 10-digit phone number


        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isHeader = true;
                List<string> invalidRecords = new List<string>();


                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader) // Skip the header row
                    {
                        isHeader = false;
                        continue;
                    }


                    string[] data = line.Split(',');


                    if (data.Length < 5) // Ensure all columns exist
                    {
                        invalidRecords.Add($"Invalid row (Missing columns): {line}");
                        continue;
                    }


                    string email = data[3].Trim();
                    string phone = data[4].Trim();


                    bool isValidEmail = Regex.IsMatch(email, emailPattern);
                    bool isValidPhone = Regex.IsMatch(phone, phonePattern);


                    if (!isValidEmail || !isValidPhone)
                    {
                        string errorMsg = $"Invalid row: {line} | Errors: ";
                        if (!isValidEmail) errorMsg += "Invalid Email Format. ";
                        if (!isValidPhone) errorMsg += "Invalid Phone Number.";
                        invalidRecords.Add(errorMsg);
                    }
                }


                // Print all invalid rows
                if (invalidRecords.Count > 0)
                {
                    Console.WriteLine("Invalid Records Found:");
                    foreach (var record in invalidRecords)
                    {
                        Console.WriteLine(record);
                    }
                }
                else
                {
                    Console.WriteLine("All records are valid!");
                }
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
