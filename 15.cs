using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<V, List<K>> InvertDictionary<K, V>(Dictionary<K, V> inputDict)
    {
        Dictionary<V, List<K>> invertedDict = new Dictionary<V, List<K>>();

        foreach (var pair in inputDict)
        {
            if (!invertedDict.ContainsKey(pair.Value))
            {
                invertedDict[pair.Value] = new List<K>();
            }
            invertedDict[pair.Value].Add(pair.Key);
        }

        return invertedDict;
    }

    static void Main()
    {
        Dictionary<string, int> inputDict = new Dictionary<string, int>
        {
            { "A", 1 },
            { "B", 2 },
            { "C", 1 }
        };

        Dictionary<int, List<string>> invertedDict = InvertDictionary(inputDict);

        // Display result
        Console.WriteLine("Inverted Dictionary:");
        foreach (var pair in invertedDict)
       
