using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string filePath = "sample.txt"; // Change this to your actual file path

        try
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Remove punctuation and split into words
                    string[] words = Regex.Replace(line, @"[^\w\s]", "").ToLower().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in words)
                    {
                        if (wordCount.ContainsKey(word))
                            wordCount[word]++;
                        else
                            wordCount[word] = 1;
                    }
                }
            }

            // Sort words by frequency (descending) and take top 5
            var topWords = wordCount.OrderByDescending(w => w.Value).Take(5);

            // Display word count
            Console.WriteLine($"Total words in file: {wordCount.Values.Sum()}");
            Console.WriteLine("\nTop 5 Most Frequent Words:");
            foreach (var word in topWords)
            {
                Console.WriteLine($"{word.Key}: {word.Value} times");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
    }
}



using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "data.txt";

        try
        {
            // Attempt to read the file
            string content = File.ReadAllText(filePath);
            Console.WriteLine("File Contents:");
            Console.WriteLine(content);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred while accessing the file: " + ex.Message);
        }
    }
}

