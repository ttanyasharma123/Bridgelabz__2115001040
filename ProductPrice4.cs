using System;

class QuickSortExample
{
    // Partition function: Places pivot in correct position and partitions the array
    static int Partition(int[] prices, int low, int high)
    {
        int pivot = prices[high]; // Choosing the last element as pivot
        int i = low - 1; // Pointer for smaller elements

        for (int j = low; j < high; j++)
        {
            // If current element is smaller than or equal to pivot, swap it
            if (prices[j] <= pivot)
            {
                i++;
                Swap(prices, i, j);
            }
        }

        // Swap pivot element with element at (i+1) to place pivot correctly
        Swap(prices, i + 1, high);
        return i + 1; // Return the pivot index
    }

    // Quick Sort function: Recursively sorts the array
    static void QuickSort(int[] prices, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(prices, low, high); // Get pivot position

            // Recursively sort elements before and after the pivot
            QuickSort(prices, low, pivotIndex - 1);
            QuickSort(prices, pivotIndex + 1, high);
        }
    }

    // Swap function: Swaps two elements in the array
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static void Main()
    {
        // Array of unsorted product prices
        int[] productPrices = { 999, 499, 1200, 750, 350, 2000, 600 };

        // Display original prices
        Console.WriteLine("Before Sorting: " + string.Join(", ", productPrices));

        // Call QuickSort to sort the prices
        QuickSort(productPrices, 0, productPrices.Length - 1);

        // Display sorted prices
        Console.WriteLine("After Sorting: " + string.Join(", ", productPrices));
    }
}
