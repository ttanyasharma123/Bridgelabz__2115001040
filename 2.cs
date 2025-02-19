using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, int> CountFrequency(List<string> items)
    {
        Dictionary<string, int> frequency = new Dictionary<string, int>();

        foreach (string item in items)
        {
            if (frequency.ContainsKey(item))
                frequency[item]++;
            else
                frequency[item] = 1;
        }

        return frequency;
    }

    static void Main()
    {
        List<string> fruits = new List<string> { "apple", "banana", "apple", "orange" };
        Dictionary<string, int> result = CountFrequency(fruits);

        Console.WriteLine("Frequency of elements:");
        foreach (var pair in result)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
