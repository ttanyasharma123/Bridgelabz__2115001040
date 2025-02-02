using System;

public class FriendInfo
{
    // Method to find the youngest friend based on their age
    public static string FindYoungestFriend(int[] ages, string[] friends)
    {
        int minAge = ages[0];
        string youngestFriend = friends[0];

        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < minAge)
            {
                minAge = ages[i];
                youngestFriend = friends[i];
            }
        }
        return youngestFriend;
    }

    // Method to find the tallest friend based on their height
    public static string FindTallestFriend(double[] heights, string[] friends)
    {
        double maxHeight = heights[0];
        string tallestFriend = friends[0];

        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > maxHeight)
            {
                maxHeight = heights[i];
                tallestFriend = friends[i];
            }
        }
        return tallestFriend;
    }

    // Main method
    public static void Main()
    {
        // Arrays to store the names, ages, and heights of the friends
        string[] friends = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        double[] heights = new double[3];

        // Take user input for ages and heights of the 3 friends
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter age for " + friends[i] + ": ");
            ages[i] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter height (in meters) for " + friends[i] + ": ");
            heights[i] = Convert.ToDouble(Console.ReadLine());
        }

        // Find the youngest friend
        string youngestFriend = FindYoungestFriend(ages, friends);
        Console.WriteLine("The youngest friend is: " + youngestFriend);

        // Find the tallest friend
        string tallestFriend = FindTallestFriend(heights, friends);
        Console.WriteLine("The tallest friend is: " + tallestFriend);
    }
}
