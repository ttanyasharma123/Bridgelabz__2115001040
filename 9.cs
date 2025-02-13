using System;
using System.Collections.Generic;

class CustomHashMap<K, V>
{
    private const int Size = 1000;
    private LinkedList<KeyValuePair<K, V>>[] buckets;

    public CustomHashMap()
    {
        buckets = new LinkedList<KeyValuePair<K, V>>[Size];
        for (int i = 0; i < Size; i++)
        {
            buckets[i] = new LinkedList<KeyValuePair<K, V>>();
        }
    }

    private int GetBucketIndex(K key)
    {
        return Math.Abs(key.GetHashCode()) % Size;
    }

    public void Insert(K key, V value)
    {
        int index = GetBucketIndex(key);
        if (buckets[index] == null)
            buckets[index] = new LinkedList<KeyValuePair<K, V>>();

        var bucket = buckets[index];

        foreach (var node in bucket)
        {
            if (node.Key.Equals(key))
            {
                bucket.Remove(node);
                break;
            }
        }

        bucket.AddLast(new KeyValuePair<K, V>(key, value));
    }

    public V Get(K key)
    {
        int index = GetBucketIndex(key);
        if (buckets[index] == null) throw new KeyNotFoundException("Key not found");

        var bucket = buckets[index];

        foreach (var node in bucket)
        {
            if (node.Key.Equals(key))
            {
                return node.Value;
            }
        }

        throw new KeyNotFoundException("Key not found");
    }

    public void Remove(K key)
    {
        int index = GetBucketIndex(key);
        if (buckets[index] == null) return;

        var bucket = buckets[index];

        foreach (var node in bucket)
        {
            if (node.Key.Equals(key))
            {
                bucket.Remove(node);
                return;
            }
        }
    }

    public bool ContainsKey(K key)
    {
        int index = GetBucketIndex(key);
        if (buckets[index] == null) return false;

        var bucket = buckets[index];

        foreach (var node in bucket)
        {
            if (node.Key.Equals(key))
            {
                return true;
            }
        }
        return false;
    }
}

class Program
{
    public static void Main()
    {
        CustomHashMap<int, string> map = new CustomHashMap<int, string>();
        map.Insert(1, "One");
        map.Insert(2, "Two");
        Console.WriteLine("Value for key 1: " + map.Get(1));
        Console.WriteLine("Contains key 2: " + map.ContainsKey(2));
        map.Remove(1);

        try
        {
            Console.WriteLine("Value for key 1: " + map.Get(1));
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
