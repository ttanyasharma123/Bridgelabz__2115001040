using System;
using System.IO;
using System.Text;

class UpperToLowerConverter
{
    static void Main()
    {
        // Define file paths
        string sourceFilePath = @"C:\Users\tanya\Desktop\source.txt";  
        string destinationFilePath = @"C:\Users\tanya\Desktop\converted.txt";

        try
        {
            // Check if source file exists
            if (!File.Exists(sourceFilePath))
            {
                Console.WriteLine("Error: Source file does not exist. Please create 'source.txt' on Desktop.");
                return;
            }

            // Read from source file and write to destination file
            using (FileStream fsRead = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            using (BufferedStream bsRead = new BufferedStream(fsRead))
            using (StreamReader reader = new StreamReader(bsRead, Encoding.UTF8)) // Handle encoding
            using (FileStream fsWrite = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
            using (BufferedStream bsWrite = new BufferedStream(fsWrite))
            using (StreamWriter writer = new StreamWriter(bsWrite, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line.ToLower()); // Convert to lowercase
                }
            }

            Console.WriteLine($"Conversion completed! Check '{destinationFilePath}' on your Desktop.");
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
}

