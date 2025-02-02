using System;

namespace ZaraBonus
{
    class Program
    {
        // Method to determine the salary and years of service using random values
        public static double[,] GetEmployeeDetails()
        {
            Random rand = new Random();
            double[,] employeeDetails = new double[10, 2]; // 2D array to store salary and years of service

            for (int i = 0; i < 10; i++)
            {
                // Random 5-digit salary between 50000 and 99999
                employeeDetails[i, 0] = rand.Next(50000, 100000);

                // Random years of service between 1 and 10
                employeeDetails[i, 1] = rand.Next(1, 11);
            }

            return employeeDetails;
        }

        // Method to calculate the new salary and bonus based on years of service
        public static double[,] CalculateBonusAndNewSalary(double[,] employeeDetails)
        {
            double[,] updatedSalariesAndBonuses = new double[10, 3]; // 2D array to store new salary and bonus

            for (int i = 0; i < 10; i++)
            {
                double salary = employeeDetails[i, 0];
                double yearsOfService = employeeDetails[i, 1];
                double bonus = 0;

                // Determine bonus percentage based on years of service
                if (yearsOfService > 5)
                {
                    bonus = salary * 0.05; // 5% bonus for employees with more than 5 years of service
                }
                else
                {
                    bonus = salary * 0.02; // 2% bonus for employees with less than 5 years of service
                }

                // Calculate the new salary
                double newSalary = salary + bonus;

                // Store the new salary and bonus in the array
                updatedSalariesAndBonuses[i, 0] = salary; // Old salary
                updatedSalariesAndBonuses[i, 1] = newSalary; // New salary
                updatedSalariesAndBonuses[i, 2] = bonus; // Bonus
            }

            return updatedSalariesAndBonuses;
        }

        // Method to calculate and display the sum of old salary, new salary, and total bonus
        public static void CalculateAndDisplaySalariesAndBonus(double[,] updatedSalariesAndBonuses)
        {
            double sumOldSalary = 0;
            double sumNewSalary = 0;
            double totalBonus = 0;

            // Displaying the header of the table
            Console.WriteLine("Employee\tOld Salary\tNew Salary\tBonus");
            Console.WriteLine("--------------------------------------------------");

            // Displaying the details of each employee and calculating totals
            for (int i = 0; i < 10; i++)
            {
                double oldSalary = updatedSalariesAndBonuses[i, 0];
                double newSalary = updatedSalariesAndBonuses[i, 1];
                double bonus = updatedSalariesAndBonuses[i, 2];

                Console.WriteLine((i + 1) + "\t\t" + oldSalary.ToString("C") + "\t\t" + newSalary.ToString("C") + "\t\t" + bonus.ToString("C"));

                // Calculate sums
                sumOldSalary += oldSalary;
                sumNewSalary += newSalary;
                totalBonus += bonus;
            }

            // Display the sum of the old salary, new salary, and total bonus
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Total Old Salary: " + sumOldSalary.ToString("C"));
            Console.WriteLine("Total New Salary: " + sumNewSalary.ToString("C"));
            Console.WriteLine("Total Bonus: " + totalBonus.ToString("C"));
        }

        static void Main(string[] args)
        {
            // Get the employee details (random salary and years of service)
            double[,] employeeDetails = GetEmployeeDetails();

            // Calculate bonus and new salary
            double[,] updatedSalariesAndBonuses = CalculateBonusAndNewSalary(employeeDetails);

            // Display the details in a tabular format
            CalculateAndDisplaySalariesAndBonus(updatedSalariesAndBonuses);
        }
    }
}
