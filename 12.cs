using System;

public class RandomNumberGenerator
{
    // Method to generate an array of 4-digit random numbers
    public static int[] Generate4DigitRandomArray(int size)
    {
        Random random = new Random();
        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            // Generating a 4-digit random number between 1000 and 9999
            numbers[i] = random.Next(1000, 10000);
        }

        return numbers;
    }

    // Method to find the average, min, and max of an array
    public static double[] FindAverageMinMax(int[] numbers)
    {
        double[] result = new double[3];

        double sum = 0;
        int min = numbers[0];
        int max = numbers[0];

        // Iterate through the array to calculate sum, min, and max
        foreach (var number in numbers)
        {
            sum += number;
            min = Math.Min(min, number);
            max = Math.Max(max, number);
        }

        result[0] = sum / numbers.Length; // Average
        result[1] = min; // Minimum value
        result[2] = max; // Maximum value

        return result;
    }

    public static void Main()
    {
        // Generate 5 random 4-digit numbers
        int[] randomNumbers = Generate4DigitRandomArray(5);

        // Find average, min, and max
        double[] stats = FindAverageMinMax(randomNumbers);

        // Display the results
        Console.WriteLine("Generated 4-digit numbers: ");
        foreach (var number in randomNumbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nAverage: " + stats[0]);
        Console.WriteLine("Minimum value: " + stats[1]);
        Console.WriteLine("Maximum value: " + stats[2]);
    }
}
