using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < 1000000; i++)
        {
            result.Append("a"); // Efficient for large N
        }
        Console.WriteLine("StringBuilder concatenation done.");
    }
}
