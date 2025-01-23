using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Amar's age: ");
        int amarAge = int.Parse(Console.ReadLine());
        Console.Write("Enter Amar's height in cm: ");
        double amarHeight = double.Parse(Console.ReadLine());

        Console.Write("Enter Akbar's age: ");
        int akbarAge = int.Parse(Console.ReadLine());
        Console.Write("Enter Akbar's height in cm: ");
        double akbarHeight = double.Parse(Console.ReadLine());

        Console.Write("Enter Anthony's age: ");
        int anthonyAge = int.Parse(Console.ReadLine());
        Console.Write("Enter Anthony's height in cm: ");
        double anthonyHeight = double.Parse(Console.ReadLine());

        int youngestAge = Math.Min(amarAge, Math.Min(akbarAge, anthonyAge));
        string youngestFriend = (youngestAge == amarAge) ? "Amar" :
                                 (youngestAge == akbarAge) ? "Akbar" : "Anthony";
        Console.WriteLine("The youngest friend is " + youngestFriend + ", with age " + youngestAge + ".");

        double tallestHeight = Math.Max(amarHeight, Math.Max(akbarHeight, anthonyHeight));
        string tallestFriend = (tallestHeight == amarHeight) ? "Amar" :
                               (tallestHeight == akbarHeight) ? "Akbar" : "Anthony";
        Console.WriteLine("The tallest friend is " + tallestFriend + ", with height " + tallestHeight + " cm.");

        Console.Write("Enter a number to find its greatest factor (besides the number itself): ");
        int num = int.Parse(Console.ReadLine());

        int greatestFactor = 1;
        for (int i = 2; i <= num / 2; i++)
        {
            if (num % i == 0)
            {
                greatestFactor = i;
            }
        }
        Console.WriteLine("The greatest factor of " + num + " (besides itself) is " + greatestFactor + ".");
    }
}
