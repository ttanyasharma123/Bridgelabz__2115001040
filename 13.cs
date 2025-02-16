using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];
        Console.WriteLine("Enter the elements of the sorted 2D matrix:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.Write("Enter the target value to search: ");
        int target = int.Parse(Console.ReadLine());

        bool found = SearchMatrix(matrix, rows, cols, target);
        Console.WriteLine(found ? "Target found in the matrix." : "Target not found in the matrix.");
    }

    static bool SearchMatrix(int[,] matrix, int rows, int cols, int target)
    {
        int left = 0, right = rows * cols - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int midValue = matrix[mid / cols, mid % cols];

            if (midValue == target)
                return true;
            else if (midValue < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return false;
    }
}
