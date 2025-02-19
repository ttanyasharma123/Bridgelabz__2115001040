using System;
using System.Collections.Generic;

class Program
{
    static List<string> GenerateBinaryNumbers(int N)
    {
        List<string> result = new List<string>();
        Queue<string> queue = new Queue<string>();

        queue.Enqueue("1"); // Start with "1"

        for (int i = 0; i < N; i++)
        {
            string current = queue.Dequeue();
            result.Add(current);

            // Generate next two binary numbers and enqueue them
            queue.Enqueue(current + "0");
            queue.Enqueue(current + "1");
        }

        return result;
    }

    static void Main()
    {
        int N = 5;
        List<string> binaryNumbers = GenerateBinaryNumbers(N);

        Console.WriteLine("First " + N + " Binary Numbers: {" + string.Join(", ", binaryNumbers) + "}");
    }
}
