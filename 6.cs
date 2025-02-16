using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Enter the file path: ");
        string filePath = Console.ReadLine();

        Console.Write("Enter the word to count: ");
        string searchWord = Console.ReadLine();

        try
        {
            int count = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        if (word.Equals(searchWord, StringComparison.OrdinalIgnoreCase))
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine($"The word '{searchWord}' appears {count} times in the file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}