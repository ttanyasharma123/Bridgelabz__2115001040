using System;

namespace MatrixOperations
{
    class Program
    {
        // Method to create a random matrix of given rows and columns
        public static int[,] CreateRandomMatrix(int rows, int cols)
        {
            Random rand = new Random();
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(1, 10); // Random numbers between 1 and 9
                }
            }
            return matrix;
        }

        // Method to add two matrices
        public static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);
            int[,] result = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }

        // Method to subtract two matrices
        public static int[,] SubtractMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);
            int[,] result = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return result;
        }

        // Method to multiply two matrices
        public static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int rows2 = matrix2.GetLength(0);
            int cols2 = matrix2.GetLength(1);

            if (cols1 != rows2)
            {
                throw new InvalidOperationException("Matrix dimensions are not compatible for multiplication.");
            }

            int[,] result = new int[rows1, cols2];
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }

        // Method to find the transpose of a matrix
        public static int[,] TransposeMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] result = new int[cols, rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }
            return result;
        }

        // Method to find the determinant of a 2x2 matrix
        public static int Determinant2x2(int[,] matrix)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        // Method to find the determinant of a 3x3 matrix
        public static int Determinant3x3(int[,] matrix)
        {
            return matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
                - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
                + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
        }

        // Method to find the inverse of a 2x2 matrix
        public static double[,] Inverse2x2(int[,] matrix)
        {
            int det = Determinant2x2(matrix);
            if (det == 0)
            {
                throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
            }

            double[,] inverse = new double[2, 2];
            inverse[0, 0] = (double)matrix[1, 1] / det;
            inverse[0, 1] = (double)-matrix[0, 1] / det;
            inverse[1, 0] = (double)-matrix[1, 0] / det;
            inverse[1, 1] = (double)matrix[0, 0] / det;
            return inverse;
        }

        // Method to find the inverse of a 3x3 matrix (using adjugate matrix method)
        public static double[,] Inverse3x3(int[,] matrix)
        {
            int det = Determinant3x3(matrix);
            if (det == 0)
            {
                throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
            }

            double[,] adjugate = new double[3, 3];
            adjugate[0, 0] = matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1];
            adjugate[0, 1] = matrix[0, 2] * matrix[2, 1] - matrix[0, 1] * matrix[2, 2];
            adjugate[0, 2] = matrix[0, 1] * matrix[1, 2] - matrix[0, 2] * matrix[1, 1];

            adjugate[1, 0] = matrix[1, 2] * matrix[2, 0] - matrix[1, 0] * matrix[2, 2];
            adjugate[1, 1] = matrix[0, 0] * matrix[2, 2] - matrix[0, 2] * matrix[2, 0];
            adjugate[1, 2] = matrix[0, 2] * matrix[1, 0] - matrix[0, 0] * matrix[1, 2];

            adjugate[2, 0] = matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0];
            adjugate[2, 1] = matrix[0, 1] * matrix[2, 0] - matrix[0, 0] * matrix[2, 1];
            adjugate[2, 2] = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            double[,] inverse = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    inverse[i, j] = adjugate[i, j] / det;
                }
            }

            return inverse;
        }

        // Method to display a matrix
        public static void DisplayMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        // Method to display a double matrix (for inverse)
        public static void DisplayMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(Math.Round(matrix[i, j], 2) + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[,] matrixA = CreateRandomMatrix(3, 3); // Create a 3x3 matrix
            int[,] matrixB = CreateRandomMatrix(3, 3); // Create another 3x3 matrix

            // Display matrices
            Console.WriteLine("Matrix A:");
            DisplayMatrix(matrixA);

            Console.WriteLine("\nMatrix B:");
            DisplayMatrix(matrixB);

            // Add matrices
            Console.WriteLine("\nMatrix A + Matrix B:");
            DisplayMatrix(AddMatrices(matrixA, matrixB));

            // Subtract matrices
            Console.WriteLine("\nMatrix A - Matrix B:");
            DisplayMatrix(SubtractMatrices(matrixA, matrixB));

            // Multiply matrices
            Console.WriteLine("\nMatrix A * Matrix B:");
            DisplayMatrix(MultiplyMatrices(matrixA, matrixB));

            // Transpose matrix
            Console.WriteLine("\nTranspose of Matrix A:");
            DisplayMatrix(TransposeMatrix(matrixA));

            // Determinant of 3x3 matrix
            Console.WriteLine("\nDeterminant of Matrix A: " + Determinant3x3(matrixA));

            // Inverse of 3x3 matrix
            Console.WriteLine("\nInverse of Matrix A:");
            DisplayMatrix(Inverse3x3(matrixA));
        }
    }
}
