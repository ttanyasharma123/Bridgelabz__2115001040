using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "path_to_your_large_file.txt";
        
        // Start timing
        var startTime = DateTime.Now;

        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[8192]; // Buffer size of 8KB
            int bytesRead;
            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
            {
                // Process the bytes read from the file
            }
        }

        var endTime = DateTime.Now;
        Console.WriteLine("FileStream reading time: " + (endTime - startTime).TotalSeconds + " seconds");
    }
}
