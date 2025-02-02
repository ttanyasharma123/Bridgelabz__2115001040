using System;

namespace CalendarApp
{
    class Program
    {
        // Array to store the names of the months
        static string[] monthNames = {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };

        // Array to store the number of days in each month
        static int[] daysInMonth = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

        // Method to check for leap year
        public static bool IsLeapYear(int year)
        {
            // Leap year is divisible by 4, but not by 100 unless also divisible by 400
            return (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
        }

        // Method to get the number of days in a month
        public static int GetDaysInMonth(int month, int year)
        {
            // If it's February, check for leap year
            if (month == 2 && IsLeapYear(year))
            {
                return 29;  // Leap year, February has 29 days
            }
            return daysInMonth[month - 1];  // Return days for other months
        }

        // Method to get the first day of the month using Gregorian calendar algorithm
        public static int GetFirstDayOfMonth(int year, int month)
        {
            int y0 = year - (14 - month) / 12;
            int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
            int m0 = month + 12 * ((14 - month) / 12) - 2;
            int d0 = (1 + x + 31 * m0 / 12) % 7;
            return d0;
        }

        // Method to display the calendar for a given month and year
        public static void DisplayCalendar(int year, int month)
        {
            int daysInMonth = GetDaysInMonth(month, year);
            int firstDay = GetFirstDayOfMonth(year, month);

            // Display the month and year
            Console.WriteLine(monthNames[month - 1] + " " + year);

            // Display the days of the week
            Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

            // Print the leading spaces based on the first day of the month
            for (int i = 0; i < firstDay; i++)
            {
                Console.Write("   ");  // 3 spaces for indentation
            }

            // Print the days of the month
            int day = 1;
            for (int i = firstDay; i < 7 && day <= daysInMonth; i++)
            {
                Console.Write(day.ToString().PadRight(3));  // Display the day and right-align it
                day++;
            }
            Console.WriteLine();

            // Now print the rest of the days in subsequent weeks
            while (day <= daysInMonth)
            {
                for (int i = 0; i < 7 && day <= daysInMonth; i++)
                {
                    Console.Write(day.ToString().PadRight(3));  // Display the day and right-align it
                    day++;
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            // Ask the user for month and year
            Console.Write("Enter the month (1-12): ");
            int month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            // Display the calendar for the given month and year
            DisplayCalendar(year, month);
        }
    }
}
