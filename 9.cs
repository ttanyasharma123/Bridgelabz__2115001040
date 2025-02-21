using System;

class NestedTryCatchDemo
{
    static void Main()
    {
        try
        {
            // Taking array input
            Console.Write("Enter the size of the array: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] numbers = new int[size];

            Console.WriteLine($"Enter {size} elements:");
            for (int i = 0; i < size; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Taking index input
            Console.Write("Enter the index to access: ");
            int index = Convert.ToInt32(Console.ReadLine());

            try
            {
                // Trying to access the element at the given index
                int value = numbers[index];

                // Taking divisor input
                Console.Write("Enter the divisor: ");
                int divisor = Convert.ToInt32(Console.ReadLine());

                try
                {
                    // Performing division
                    int result = value / divisor;
                    Console.WriteLine($"Result: {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero!");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid array index!");
            }
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

