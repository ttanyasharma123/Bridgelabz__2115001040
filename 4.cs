using System;
using System.Collections.Generic;

class SlidingWindowMaximum
{
    // Function to find the maximum in each sliding window
    static void FindMaxInSlidingWindow(int[] arr, int k)
    {
        if (arr.Length == 0 || k <= 0)
            return;

        LinkedList<int> deque = new LinkedList<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            // Remove elements that are out of the current window
            if (deque.Count > 0 && deque.First.Value < i - k + 1)
            {
                deque.RemoveFirst();
            }

            // Remove all elements smaller than the current element
            while (deque.Count > 0 && arr[deque.Last.Value] <= arr[i])
            {
                deque.RemoveLast();
            }

            deque.AddLast(i);

            // Print maximum of current window
            if (i >= k - 1)
            {
                Console.Write(arr[deque.First.Value] + " ");
            }
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        int[] arr = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;
        
        Console.WriteLine("Sliding Window Maximum:");
        FindMaxInSlidingWindow(arr, k);
    }
}
