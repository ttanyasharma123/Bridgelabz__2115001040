using System;

class Program
{
    static void Main()
    {
        double[] salaries = new double[10];
        double[] yearsOfService = new double[10];
        double[] bonuses = new double[10];
        double[] newSalaries = new double[10];
        
        double totalBonus = 0;
        double totalOldSalary = 0;
        double totalNewSalary = 0;
        
        for (int i = 0; i < 10; i++)
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Enter salary for employee " + (i + 1) + ": ");
                if (double.TryParse(Console.ReadLine(), out salaries[i]) && salaries[i] > 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid salary entered. Please enter a valid salary.");
                }
            }

            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Enter years of service for employee " + (i + 1) + ": ");
                if (double.TryParse(Console.ReadLine(), out yearsOfService[i]) && yearsOfService[i] >= 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid years of service entered. Please enter a valid number.");
                }
            }
        }

        for (int i = 0; i < 10; i++)
        {
            if (yearsOfService[i] > 5)
            {
                bonuses[i] = salaries[i] * 0.05;
            }
            else
            {
                bonuses[i] = salaries[i] * 0.02;
            }

            newSalaries[i] = salaries[i] + bonuses[i];
            totalBonus += bonuses[i];
            totalOldSalary += salaries[i];
            totalNewSalary += newSalaries[i];
        }

        Console.WriteLine("\nTotal Bonus Payout: " + totalBonus);
        Console.WriteLine("Total Old Salary: " + totalOldSalary);
        Console.WriteLine("Total New Salary: " + totalNewSalary);
    }
}
