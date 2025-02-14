using System;

class HeapSortExample
{
    // Heapify function: Ensures the subtree with root at 'i' follows the max heap property
    static void Heapify(int[] salaries, int n, int i)
    {
        int largest = i; // Assume root is the largest
        int left = 2 * i + 1;  // Left child index
        int right = 2 * i + 2; // Right child index

        // If left child is larger than root
        if (left < n && salaries[left] > salaries[largest])
        {
            largest = left;
        }

        // If right child is larger than the current largest
        if (right < n && salaries[right] > salaries[largest])
        {
            largest = right;
        }

        // If the largest is not root, swap and continue heapifying
        if (largest != i)
        {
            Swap(salaries, i, largest);
            Heapify(salaries, n, largest);
        }
    }

    // Heap Sort function: Sorts the array using Heap Sort
    static void HeapSort(int[] salaries)
    {
        int n = salaries.Length;

        // Build a Max Heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(salaries, n, i);
        }

        // Extract elements from heap one by one
        for (int i = n - 1; i > 0; i--)
        {
            Swap(salaries, 0, i); // Move current root to end
            Heapify(salaries, i, 0); // Heapify reduced heap
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
        // Array of salary demands (unsorted)
        int[] salaryDemands = { 55000, 75000, 42000, 60000, 90000, 50000 };

        // Display original salary demands
        Console.WriteLine("Before Sorting: " + string.Join(", ", salaryDemands));

        // Call HeapSort to sort the salary demands
        HeapSort(salaryDemands);

        // Display sorted salary demands
        Console.WriteLine("After Sorting: " + string.Join(", ", salaryDemands));
    }
}
