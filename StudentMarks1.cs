using System;

class StudentMarksSorter
{
    // This method sorts an array using Bubble Sort
    static void BubbleSort(int[] marks)
    {
        int n = marks.Length;

        // Outer loop: Controls how many passes we make over the array
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false; // Keep track of whether we made any swaps

            // Inner loop: Compare adjacent elements and swap if needed
            for (int j = 0; j < n - i - 1; j++)
            {
                if (marks[j] > marks[j + 1]) // If left element is bigger, swap them
                {
                    int temp = marks[j];
                    marks[j] = marks[j + 1];
                    marks[j + 1] = temp;
                    swapped = true; // Mark that a swap happened
                }
            }

            // If no swaps were made, the array is already sorted – stop early!
            if (!swapped)
                break;
        }
    }

    static void Main()
    {
        // Array containing student marks
        int[] studentMarks = { 75, 98, 85, 60, 45, 90, 70 };

        // Display the original list of marks
        Console.WriteLine("Before Sorting: " + string.Join(", ", studentMarks));

        // Call BubbleSort to sort the marks
        BubbleSort(studentMarks);

        // Display the sorted list of marks
        Console.WriteLine("After Sorting: " + string.Join(", ", studentMarks));
    }
}
