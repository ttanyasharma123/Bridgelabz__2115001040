using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static Dictionary<string, int> CountWordFrequency(string text)
    {
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

        // Convert to lowercase and split words using regex (handles punctuation)
        string[] words = Regex.Split(text.ToLower(), @"\W+");

        foreach (string word in words)
        {
            if (!string.IsNullOrEmpty(word)) // Ignore empty strings
            {
                if (wordFrequency.ContainsKey(word))
                    wordFrequency[word]++;
                else
                    wordFrequency[word] = 1;
            }
        }
        return wordFrequency;
    }

    static void Main()
    {
        // Read text from a file (optional) or use a string
        string text = "Hello world, hello Java!";

        Dictionary<string, int> frequencyMap = CountWordFrequency(text);

        // Display result
        Console.WriteLine("Word Frequency:");
        foreach (var pair in frequencyMap)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
