using System;
using System.IO;

class UserInputToFile
{
    static void Main()
    {
        string filePath = @"C:\Users\tanya\Desktop\user_data.txt";  // File to store user input

        try
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your age:");
            string age = Console.ReadLine();

            Console.WriteLine("Enter your favorite programming language:");
            string language = Console.ReadLine();

            // Writing user input to file using StreamWriter
            using (StreamWriter writer = new StreamWriter(filePath, true)) // 'true' appends to file
            {
                writer.WriteLine("User Information:");
                writer.WriteLine($"Name: {name}");
                writer.WriteLine($"Age: {age}");
                writer.WriteLine($"Favorite Language: {language}");
                writer.WriteLine("----------------------------------");
            }

            Console.WriteLine($"User data saved successfully in {filePath}");
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
        }
    }
}



