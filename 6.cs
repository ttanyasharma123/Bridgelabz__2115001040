using System;

class SpringSeason
{
    // Main method
    static void Main(string[] args)
    {
        // Check if the user has entered two arguments (month and day)
        if (args.Length != 2)
        {
            Console.WriteLine("Please provide two integer values: month and day.");
            return;
        }

        // Parse the command line arguments into integers
        int month = Convert.ToInt32(args[0]);
        int day = Convert.ToInt32(args[1]);

        // Check if the date is in Spring season
        if (IsSpringSeason(month, day))
        {
            Console.WriteLine("It's a Spring Season.");
        }
        else
        {
            Console.WriteLine("Not a Spring Season.");
        }
    }

    // Method to check if the given date is in Spring season
    static bool IsSpringSeason(int month, int day)
    {
        // Spring Season is from March 20 to June 20
        if ((month == 3 && day >= 20) || month == 4 || month == 5 || (month == 6 && day <= 20))
        {
            return true;
        }
        return false;
    }
}
