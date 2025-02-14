using System;

class MergeSortExample
{
    // Merge function: Combines two sorted halves into one sorted array
    static void Merge(int[] prices, int left, int mid, int right)
    {
        int n1 = mid - left + 1; // Size of left half
        int n2 = right - mid;    // Size of right half

        // Temporary arrays to hold the divided elements
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        // Copy data to temporary arrays
        for (int i = 0; i < n1; i++)
            leftArray[i] = prices[left + i];

        for (int j = 0; j < n2; j++)
            rightArray[j] = prices[mid + 1 + j];

        // Merging the two halves back into the original array
        int x = 0, y = 0, k = left;

        while (x < n1 && y < n2)
        {
            if (leftArray[x] <= rightArray[y]) // Compare and insert the smaller value
            {
                prices[k] = leftArray[x];
                x++;
            }
            else
            {
                prices[k] = rightArray[y];
                y++;
            }
            k++;
        }

        // Copy any remaining elements from the left half (if any)
        while (x < n1)
        {
            prices[k] = leftArray[x];
            x++;
            k++;
        }

        // Copy any remaining elements from the right half (if any)
        while (y < n2)
        {
            prices[k] = rightArray[y];
            y++;
            k++;
        }
    }

    // Merge Sort function: Recursively divides the array and sorts it
    static void MergeSort(int[] prices, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2; // Find the middle point

            // Recursively sort the left half
            MergeSort(prices, left, mid);

            // Recursively sort the right half
            MergeSort(prices, mid + 1, right);

            // Merge the two sorted halves
            Merge(prices, left, mid, right);
        }
    }

    static void Main()
    {
        // Array of unsorted book prices
        int[] bookPrices = { 350, 120, 500, 275, 90, 600, 200 };

        // Display original prices
        Console.WriteLine("Before Sorting: " + string.Join(", ", bookPrices));

        // Call MergeSort to sort the prices
        MergeSort(bookPrices, 0, bookPrices.Length - 1);

        // Display sorted prices
        Console.WriteLine("After Sorting: " + string.Join(", ", bookPrices));
    }
}
