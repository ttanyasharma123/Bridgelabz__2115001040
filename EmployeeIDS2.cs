using System;

class EmployeeIDSorter
{
    // This method sorts an array using Insertion Sort
    static void InsertionSort(int[] employeeIDs)
    {
        int n = employeeIDs.Length;

        // Start from the second element (index 1) because the first element is already "sorted"
        for (int i = 1; i < n; i++)
        {
            int key = employeeIDs[i]; // The element we need to place in the correct position
            int j = i - 1; // Start comparing with the previous element

            // Shift elements that are greater than "key" one position ahead
            while (j >= 0 && employeeIDs[j] > key)
            {
                employeeIDs[j + 1] = employeeIDs[j];
                j--; // Move left
            }

            // Place the key in its correct position
            employeeIDs[j + 1] = key;
        }
    }

    static void Main()
    {
        // Array of unsorted employee IDs
        int[] employeeIDs = { 104, 102, 109, 101, 107 };

        // Display original list
        Console.WriteLine("Before Sorting: " + string.Join(", ", employeeIDs));

        // Call InsertionSort to sort the IDs
        InsertionSort(employeeIDs);

        // Display sorted list
        Console.WriteLine("After Sorting: " + string.Join(", ", employeeIDs));
    }
}
