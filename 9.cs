using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of columns: ");
        int columns = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write("Enter element at position (" + (i + 1) + ", " + (j + 1) + "): ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int[] oneDArray = new int[rows * columns];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                oneDArray[index] = matrix[i, j];
                index++;
            }
        }

        Console.WriteLine("\nThe 1D array after copying elements from the 2D array:");
        for (int i = 0; i < oneDArray.Length; i++)
        {
            Console.Write(oneDArray[i] + " ");
        }
    }
}
