using System;
using System.IO;

class FileHandlingExample
{
    static void Main()
    {
        // Use absolute paths for better reliability
        string sourceFile = @"C:\Users\tanya\Desktop\source.txt";  
        string destinationFile = @"C:\Users\tanya\Desktop\destination.txt";  

        try
        {
            // Debugging - Show where the program is looking for the file
            Console.WriteLine("Looking for file at: " + Path.GetFullPath(sourceFile));

            // Check if source file exists
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("Error: Source file does not exist. Please create the file at the specified path.");
                return;
            }

            // Open FileStream for reading and writing
            using (FileStream fsRead = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (FileStream fsWrite = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[1024]; // Buffer for efficient reading
                int bytesRead;

                // Read and write data in chunks
                while ((bytesRead = fsRead.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsWrite.Write(buffer, 0, bytesRead);
                }
            }

            Console.WriteLine("File copied successfully! Check 'destination.txt' on your desktop.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}

