using System;
using System.Collections.Generic;

class PairWithGivenSum
{
    // Function to check for a pair with the given sum
    static bool HasPairWithSum(int[] arr, int target)
    {
        HashSet<int> seen = new HashSet<int>();

        foreach (int num in arr)
        {
            int complement = target - num;
            if (seen.Contains(complement))
            {
                Console.WriteLine("Pair found: (" + complement + ", " + num + ")");
                return true;
            }
            seen.Add(num);
        }
        
        Console.WriteLine("No pair found");
        return false;
    }

    public static void Main()
    {
        int[] arr = { 1, 4, 45, 6, 10, 8 };
        int target = 16;
        
        HasPairWithSum(arr, target);
    }
}
