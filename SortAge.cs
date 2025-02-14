using System;

class CountingSortExample
{
    // Counting Sort function: Sorts an array of ages
    static void CountingSort(int[] ages, int minAge, int maxAge)
    {
        int range = maxAge - minAge + 1; // Calculate the range of ages
        int[] count = new int[range];    // Count array to store frequency of each age
        int[] output = new int[ages.Length]; // Output array to store sorted ages

        // Step 1: Count occurrences of each age
        for (int i = 0; i < ages.Length; i++)
        {
            count[ages[i] - minAge]++; // Adjust index to start from 0
        }

        // Step 2: Compute cumulative frequency
        for (int i = 1; i < range; i++)
        {
            count[i] += count[i - 1]; // Update count[i] to store position of next occurrence
        }

        // Step 3: Place elements in correct positions in output array
        for (int i = ages.Length - 1; i >= 0; i--)
        {
            output[count[ages[i] - minAge] - 1] = ages[i]; // Place in correct index
            count[ages[i] - minAge]--; // Decrease count
        }

        // Step 4: Copy sorted elements back to original array
        for (int i = 0; i < ages.Length; i++)
        {
            ages[i] = output[i];
        }
    }

    static void Main()
    {
        // Array of student ages (unsorted, ranging from 10 to 18)
        int[] studentAges = { 12, 15, 11, 18, 16, 10, 14, 13, 17, 15, 16, 12 };

        // Display original ages
        Console.WriteLine("Before Sorting: " + string.Join(", ", studentAges));

        // Call CountingSort to sort the ages
        CountingSort(studentAges, 10, 18);

        // Display sorted ages
        Console.WriteLine("After Sorting: " + string.Join(", ", studentAges));
    }
}
