using System;
using System.Diagnostics;
using System.IO;

class BufferedFileCopy
{
    static void Main()
    {
        // Define file paths (Change these to valid file paths on your system)
        string sourceFile = @"C:\Users\tanya\Desktop\largefile.txt";  // Large file (100MB+)
        string destBuffered = @"C:\Users\tanya\Desktop\buffered_copy.txt";
        string destUnbuffered = @"C:\Users\tanya\Desktop\unbuffered_copy.txt";

        // Check if source file exists
        if (!File.Exists(sourceFile))
        {
            Console.WriteLine("Error: Source file does not exist. Please create a large file at the specified path.");
            return;
        }

        // Measure execution time for normal file copy (unbuffered)
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        CopyFileUnbuffered(sourceFile, destUnbuffered);
        stopwatch.Stop();
        Console.WriteLine($"Unbuffered Copy Time: {stopwatch.ElapsedMilliseconds} ms");

        // Measure execution time for buffered file copy
        stopwatch.Restart();
        CopyFileBuffered(sourceFile, destBuffered);
        stopwatch.Stop();
        Console.WriteLine($"Buffered Copy Time: {stopwatch.ElapsedMilliseconds} ms");

        Console.WriteLine("File copy operations completed!");
    }

    // Normal File Copy (Unbuffered)
    static void CopyFileUnbuffered(string source, string destination)
    {
        using (FileStream fsRead = new FileStream(source, FileMode.Open, FileAccess.Read))
        using (FileStream fsWrite = new FileStream(destination, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[4096];  // 4 KB chunk size
            int bytesRead;
            while ((bytesRead = fsRead.Read(buffer, 0, buffer.Length)) > 0)
            {
                fsWrite.Write(buffer, 0, bytesRead);
            }
        }
    }

    // Buffered File Copy
    static void CopyFileBuffered(string source, string destination)
    {
        using (FileStream fsRead = new FileStream(source, FileMode.Open, FileAccess.Read))
        using (BufferedStream bsRead = new BufferedStream(fsRead, 4096)) // Buffer on reading side
        using (FileStream fsWrite = new FileStream(destination, FileMode.Create, FileAccess.Write))
        using (BufferedStream bsWrite = new BufferedStream(fsWrite, 4096)) // Buffer on writing side
        {
            byte[] buffer = new byte[4096];  // 4 KB chunk size
            int bytesRead;
            while ((bytesRead = bsRead.Read(buffer, 0, buffer.Length)) > 0)
            {
                bsWrite.Write(buffer, 0, bytesRead);
            }
        }
    }
}



