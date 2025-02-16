using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of sentences: ");
        int n = int.Parse(Console.ReadLine());
        string[] sentences = new string[n];

        Console.WriteLine("Enter the sentences:");
        for (int i = 0; i < n; i++)
        {
            sentences[i] = Console.ReadLine();
        }

        Console.Write("Enter the word to search for: ");
        string searchWord = Console.ReadLine();

        string result = FindSentenceContainingWord(sentences, searchWord);
        
        if (result != null)
        {
            Console.WriteLine("The first sentence containing the word is: " + result);
        }
        else
        {
            Console.WriteLine("No sentence contains the specified word.");
        }
    }

    static string FindSentenceContainingWord(string[] sentences, string word)
    {
        foreach (string sentence in sentences)
        {
            if (sentence.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                return sentence;
            }
        }
        return null;
    }
}