using System;

class Program
{
    static void Main()
    {
        string result = "";
        for (int i = 0; i < 1000000; i++)
        {
            result += "a"; // Inefficient for large N due to string immutability
        }
        Console.WriteLine("String concatenation done.");
    }
}
