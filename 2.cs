using System;

class Program
{
    static void Main()
    {
        string[] names = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        double[] heights = new double[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Enter age for " + names[i] + ": ");
            ages[i] = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter height (in cm) for " + names[i] + ": ");
            heights[i] = double.Parse(Console.ReadLine());
        }

        int youngestAge = ages[0];
        string youngestFriend = names[0];
        for (int i = 1; i < 3; i++)
        {
            if (ages[i] < youngestAge)
            {
                youngestAge = ages[i];
                youngestFriend = names[i];
            }
        }

        double tallestHeight = heights[0];
        string tallestFriend = names[0];
        for (int i = 1; i < 3; i++)
        {
            if (heights[i] > tallestHeight)
            {
                tallestHeight = heights[i];
                tallestFriend = names[i];
            }
        }

        Console.WriteLine("\nYoungest Friend: " + youngestFriend + " (Age: " + youngestAge + ")");
        Console.WriteLine("Tallest Friend: " + tallestFriend + " (Height: " + tallestHeight + " cm)");
    }
}
