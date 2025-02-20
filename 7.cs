using System;
using System.IO;

class StudentDataBinary
{
    static string filePath = @"C:\Users\tanya\Desktop\students.dat"; // Binary file location

    static void Main()
    {
        try
        {
            // Writing student details to a binary file
            WriteStudentData();
            Console.WriteLine("Student data saved successfully!");

            // Reading student details from the binary file
            ReadStudentData();
        }
        catch (IOException ex)
        {
            Console.WriteLine("File error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }

    // Method to write student details using BinaryWriter
    static void WriteStudentData()
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            // Writing sample student records
            writer.Write(101); // Roll Number
            writer.Write("Tanya"); // Name
            writer.Write(9.2); // GPA

            writer.Write(102);
            writer.Write("Amit");
            writer.Write(8.5);
        }
    }

    // Method to read student details using BinaryReader
    static void ReadStudentData()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: Data file not found.");
            return;
        }

        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            Console.WriteLine("\nRetrieved Student Data:");

            // Reading students until the end of the file
            while (fs.Position < fs.Length)
            {
                int rollNumber = reader.ReadInt32();
                string name = reader.ReadString();
                double gpa = reader.ReadDouble();

                Console.WriteLine($"Roll No: {rollNumber}, Name: {name}, GPA: {gpa}");
            }
        }
    }
}



