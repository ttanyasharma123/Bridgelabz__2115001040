using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

        // Compute Symmetric Difference
        HashSet<int> symmetricDifference = new HashSet<int>(set1);
        symmetricDifference.SymmetricExceptWith(set2);

        // Display result
        Console.WriteLine("Symmetric Difference: {" + string.Join(", ", symmetricDifference) + "}");
    }
}
