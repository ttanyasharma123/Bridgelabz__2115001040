using System;
using System.Collections.Generic;

class Program
{
    static List<int> RemoveDuplicates(List<int> list)
    {
        HashSet<int> seen = new HashSet<int>(); // Stores unique elements
        List<int> result = new List<int>(); // Stores elements in order

        foreach (int num in list)
        {
            if (!seen.Contains(num))
            {
                seen.Add(num);
                result.Add(num);
            }
        }

        return result;
    }

    static void Main()
    {
        List<int> numbers = new List<int> { 3, 1, 2, 2, 3, 4 };

        Console.WriteLine("Original List: " + string.Join(", ", numbers));

        List<int> uniqueList = RemoveDuplicates(numbers);

        Console.WriteLine("List after removing duplicates: " + string.Join(", ", uniqueList));
    }
}
