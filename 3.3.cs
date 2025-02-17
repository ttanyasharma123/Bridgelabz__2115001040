using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuffer result = new StringBuffer();
        for (int i = 0; i < 1000000; i++)
        {
            result.Append("a"); // Efficient for large N
        }
        Console.WriteLine("StringBuffer concatenation done.");
    }
}
