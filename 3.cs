using System;
using System.Text;

class Program
{
    static void Main()
    {
        string[] words = { "Hello", " ", "World", "!", " Welcome", " to", " C#." };

        StringBuilder sb = new StringBuilder();

        foreach (string word in words)
        {
            sb.Append(word);
        }

        Console.WriteLine("Concatenated string: " + sb.ToString());
    }
}
