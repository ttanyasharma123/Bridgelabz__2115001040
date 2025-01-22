using System;

class TotalIncome
{
    static void Main()
    {
        // Declare variables for salary and bonus
        double salary, bonus;

        // Take user input for salary
        Console.Write("Enter the salary: ");
        salary = double.Parse(Console.ReadLine());

        // Take user input for bonus
        Console.Write("Enter the bonus: ");
        bonus = double.Parse(Console.ReadLine());

        // Compute total income by adding salary and bonus
        double totalIncome = salary + bonus;

        // Print the result
        Console.WriteLine("The salary is INR {0} and bonus is INR {1}. Hence Total Income is INR {2}", salary, bonus, totalIncome);
    }
}
