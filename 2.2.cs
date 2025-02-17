using System;

class Program
{
    static void MergeSort(int[] arr)
    {
        if (arr.Length <= 1)
            return;

        int mid = arr.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[arr.Length - mid];

        Array.Copy(arr, 0, left, 0, mid);
        Array.Copy(arr, mid, right, 0, arr.Length - mid);

        MergeSort(left);
        MergeSort(right);

        Merge(arr, left, right);
    }

    static void Merge(int[] arr, int[] left, int[] right)
    {
        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                arr[k++] = left[i++];
            }
            else
            {
                arr[k++] = right[j++];
            }
        }

        while (i < left.Length)
        {
            arr[k++] = left[i++];
        }

        while (j < right.Length)
        {
            arr[k++] = right[j++];
        }
    }

    static void Main()
    {
        int[] arr = { 5, 2, 9, 1, 5, 6 };
        MergeSort(arr);
        Console.WriteLine("Sorted Array using Merge Sort:");
        foreach (var num in arr)
        {
            Console.Write(num + " ");
        }
    }
}
