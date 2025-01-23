using System;

class SpringSeason
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Please provide exactly two arguments: month and day.");
            return;
        }

        int month = int.Parse(args[0]);
        int day = int.Parse(args[1]);

        if ((month == 3 && day >= 20) || (month > 3 && month < 6) || (month == 6 && day <= 20))
        {
            Console.WriteLine("It's a Spring Season.");
        }
        else
        {
            Console.WriteLine("Not a Spring Season.");
        }
    }
}
