using System;
using System.Collections.Generic;

class LongestConsecutiveSequence
{
    // Function to find the length of the longest consecutive sequence
    static int FindLongestConsecutiveSequence(int[] arr)
    {
        HashSet<int> set = new HashSet<int>(arr);
        int longestStreak = 0;

        foreach (int num in set)
        {
            if (!set.Contains(num - 1)) // Start of a sequence
            {
                int currentNum = num;
                int currentStreak = 1;

                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentStreak++;
                }

                longestStreak = Math.Max(longestStreak, currentStreak);
            }
        }

        return longestStreak;
    }

    public static void Main()
    {
        int[] arr = { 100, 4, 200, 1, 3, 2 };
        Console.WriteLine("Length of longest consecutive sequence: " + FindLongestConsecutiveSequence(arr));
    }
}