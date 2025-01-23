using System;

class EmployeeBonus
{
    static void Main(string[] args)
    {
        Console.Write("Enter your salary: ");
        double salary;
        Console.Write("Enter your years of service: ");
        int yearsOfService;

        if (double.TryParse(Console.ReadLine(), out salary) && int.TryParse(Console.ReadLine(), out yearsOfService))
        {
            double bonus = 0;

            if (yearsOfService > 5)
            {
                bonus = salary * 0.05;
            }

            Console.WriteLine("The bonus amount is: " + bonus);
        }
        else
        {
            Console.WriteLine("Please enter valid inputs.");
        }
    }
}
