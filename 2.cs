using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        StringBuilder sb = new StringBuilder();
        HashSet<char> seen = new HashSet<char>();

        foreach (char c in input)
        {
            if (!seen.Contains(c))
            {
                sb.Append(c);
                seen.Add(c);
            }
        }

        Console.WriteLine("String after removing duplicates: " + sb.ToString());
    }
}
