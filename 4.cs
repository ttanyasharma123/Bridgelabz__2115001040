using System;
using System.Text;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int iterations = 10000;
        string text = "Hello";

        // Measure time for string concatenation using '+'
        Stopwatch sw1 = Stopwatch.StartNew();
        string result = "";
        for (int i = 0; i < iterations; i++)
        {
            result += text; // Creates new strings repeatedly (inefficient)
        }
        sw1.Stop();
        Console.WriteLine("Time taken with string (+) concatenation: " + sw1.ElapsedMilliseconds + " ms");

        // Measure time for StringBuilder
        Stopwatch sw2 = Stopwatch.StartNew();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iterations; i++)
        {
            sb.Append(text); // Efficiently modifies existing memory
        }
        sw2.Stop();
        Console.WriteLine("Time taken with StringBuilder: " + sw2.ElapsedMilliseconds + " ms");
    }
}
