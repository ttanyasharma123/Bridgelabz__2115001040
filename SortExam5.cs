using System;

class SelectionSortExample
{
    // Selection Sort function: Sorts an array in ascending order
    static void SelectionSort(int[] scores)
    {
        int n = scores.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i; // Assume the first element is the minimum

            // Find the minimum element in the unsorted part
            for (int j = i + 1; j < n; j++)
            {
                if (scores[j] < scores[minIndex])
                {
                    minIndex = j; // Update minIndex if a smaller element is found
                }
            }

            // Swap the found minimum element with the first unsorted element
            Swap(scores, i, minIndex);
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
        // Array of unsorted exam scores
        int[] examScores = { 85, 62, 90, 75, 50, 95, 70 };

        // Display original scores
        Console.WriteLine("Before Sorting: " + string.Join(", ", examScores));

        // Call SelectionSort to sort the scores
        SelectionSort(examScores);

        // Display sorted scores
        Console.WriteLine("After Sorting: " + string.Join(", ", examScores));
    }
}
