using System;

class LeapYear
{
    public static void Main()
    {
        // Take input from the user
        Console.Write("Enter a year: ");
        string input = Console.ReadLine();

        // Check if the input is a valid integer
        int year;
        if (int.TryParse(input, out year))
        {
            // Call the method to check if it's a leap year
            if (IsLeapYear(year))
            {
                Console.WriteLine(year + " is a Leap Year.");
            }
            else
            {
                Console.WriteLine(year + " is not a Leap Year.");
            }
        }
        else
        {
            // If input is not a valid number
            Console.WriteLine("Invalid input. Please enter a valid year.");
        }
    }

    // Method to check if a year is a leap year
    static bool IsLeapYear(int year)
    {
        // Check if the year is >= 1582
        if (year < 1582)
        {
            Console.WriteLine("Leap Year program works only for years 1582 or later.");
            return false;
        }

        // Leap year logic: divisible by 4 and not divisible by 100, or divisible by 400
        if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
