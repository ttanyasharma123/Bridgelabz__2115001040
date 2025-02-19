using System;
using System.Collections.Generic;

class Program
{
    static List<int> RotateList(List<int> list, int positions)
    {
        int n = list.Count;
        positions = positions % n; // Handle cases where positions > n

        List<int> rotatedList = new List<int>();

        // Add elements from 'positions' to end
        for (int i = positions; i < n; i++)
        {
            rotatedList.Add(list[i]);
        }

        // Add first 'positions' elements to the end
        for (int i = 0; i < positions; i++)
        {
            rotatedList.Add(list[i]);
        }

        return rotatedList;
    }

    static void Main()
    {
        List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };
        int rotateBy = 2;

        Console.WriteLine("Original List: " + string.Join(", ", numbers));

        List<int> rotatedList = RotateList(numbers, rotateBy);

        Console.WriteLine("Rotated List: " + string.Join(", ", rotatedList));
    }
}
