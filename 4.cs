using System;

class ArrayOperations
{
    static void Main()
    {
        try
        {
            // Accepting array input
            Console.Write("Enter the size of the array: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] numbers = null; // Initially set to null

            // Ensuring the array is created only if size is positive
            if (size > 0)
            {
                numbers = new int[size];

                Console.WriteLine($"Enter {size} elements:");
                for (int i = 0; i < size; i++)
                {
                    numbers[i] = Convert.ToInt32(Console.ReadLine());
                }
            }

            // Accepting index number
            Console.Write("Enter the index to retrieve value: ");
            int index = Convert.ToInt32(Console.ReadLine());

            // Retrieving and printing value
            Console.WriteLine($"Value at index {index}: {numbers[index]}");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid index!");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Array is not initialized!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid numeric values.");
        }
        finally
        {
            Console.WriteLine("Program execution completed.");
        }
    }
}

