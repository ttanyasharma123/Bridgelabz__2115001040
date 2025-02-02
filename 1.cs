using System;

class FootballTeam
{
    static void Main()
    {
        // Generate random heights for 11 players
        int[] heights = GenerateRandomHeights(11, 150, 250);

        // Calculate and display the sum, shortest, tallest, and mean height
        int sum = FindSumOfHeights(heights);
        int shortest = FindShortestHeight(heights);
        int tallest = FindTallestHeight(heights);
        double mean = (double)sum / heights.Length;

        // Display results
        Console.WriteLine("Player Heights: " + string.Join(", ", heights));
        Console.WriteLine("Sum of Heights: " + sum + " cm");
        Console.WriteLine("Shortest Height: " + shortest + " cm");
        Console.WriteLine("Tallest Height: " + tallest + " cm");
        Console.WriteLine("Mean Height: " + mean.ToString("F2") + " cm");
    }

    // Method to generate random heights between min and max
    static int[] GenerateRandomHeights(int count, int min, int max)
    {
        Random rand = new Random();
        int[] heights = new int[count];
        for (int i = 0; i < count; i++)
        {
            heights[i] = rand.Next(min, max + 1);
        }
        return heights;
    }

    // Method to calculate sum of all heights
    static int FindSumOfHeights(int[] heights)
    {
        int sum = 0;
        foreach (int height in heights)
        {
            sum += height;
        }
        return sum;
    }

    // Method to find the shortest height
    static int FindShortestHeight(int[] heights)
    {
        int shortest = heights[0];
        foreach (int height in heights)
        {
            if (height < shortest)
            {
                shortest = height;
            }
        }
        return shortest;
    }

    // Method to find the tallest height
    static int FindTallestHeight(int[] heights)
    {
        int tallest = heights[0];
        foreach (int height in heights)
        {
            if (height > tallest)
            {
                tallest = height;
            }
        }
        return tallest;
    }
}
