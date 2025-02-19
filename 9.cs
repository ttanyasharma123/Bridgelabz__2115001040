using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<int> numberSet = new HashSet<int> { 5, 3, 9, 1 };

        // Convert to a List and Sort
        List<int> sortedList = new List<int>(numberSet);
        sortedList.Sort(); // Sorts in ascending order

        // Display result
        Console.WriteLine("Sorted List: [" + string.Join(", ", sortedList) + "]");
    }
}
