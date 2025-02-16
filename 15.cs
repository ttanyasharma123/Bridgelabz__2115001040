using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of elements in the list: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        Console.WriteLine("Enter the elements of the list:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int missingPositive = FindFirstMissingPositive(arr);
        Console.WriteLine("The first missing positive integer is: " + missingPositive);

        Console.Write("Enter the target number to search for: ");
        int target = int.Parse(Console.ReadLine());
        
        Array.Sort(arr);
        int targetIndex = BinarySearch(arr, target);
        Console.WriteLine(targetIndex != -1 ? $"The target number is found at index: {targetIndex}" : "Target number not found.");
    }

    static int FindFirstMissingPositive(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            while (arr[i] > 0 && arr[i] <= n && arr[arr[i] - 1] != arr[i])
            {
                int temp = arr[i];
                arr[i] = arr[temp - 1];
                arr[temp - 1] = temp;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (arr[i] != i + 1)
            {
                return i + 1;
            }
        }
        return n + 1;
    }

    static int BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
}
