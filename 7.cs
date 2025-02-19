using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

        // Compute Union
        HashSet<int> unionSet = new HashSet<int>(set1);
        unionSet.UnionWith(set2);

        // Compute Intersection
        HashSet<int> intersectionSet = new HashSet<int>(set1);
        intersectionSet.IntersectWith(set2);

        // Display results
        Console.WriteLine("Union: {" + string.Join(", ", unionSet) + "}");
        Console.WriteLine("Intersection: {" + string.Join(", ", intersectionSet) + "}");
    }
}
