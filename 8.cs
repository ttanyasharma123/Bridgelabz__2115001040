using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class Program
{
    static void Main()
    {
        using (AnonymousPipeServerStream pipeServer = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
        using (AnonymousPipeClientStream pipeClient = new AnonymousPipeClientStream(PipeDirection.In, pipeServer.GetClientHandleAsString()))
        {
            Thread writerThread = new Thread(() => WriteData(pipeServer));
            Thread readerThread = new Thread(() => ReadData(pipeClient));

            writerThread.Start();
            readerThread.Start();

            writerThread.Join();
            readerThread.Join();
        }
    }

    static void WriteData(PipeStream pipe)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(pipe))
            {
                writer.AutoFlush = true;
                for (int i = 1; i <= 5; i++)
                {
                    string message = $"Message {i}";
                    Console.WriteLine($"[Writer] Sending: {message}");
                    writer.WriteLine(message);
                    Thread.Sleep(500); // Simulating delay
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"[Writer] Error: {ex.Message}");
        }
    }

    static void ReadData(PipeStream pipe)
    {
        try
        {
            using (StreamReader reader = new StreamReader(pipe))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"[Reader] Received: {line}");
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"[Reader] Error: {ex.Message}");
        }
    }
}
