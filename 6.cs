using System;

class BMIProgram
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of persons: ");
        int numberOfPersons = int.Parse(Console.ReadLine());

        double[] heights = new double[numberOfPersons];
        double[] weights = new double[numberOfPersons];
        double[] bmis = new double[numberOfPersons];
        string[] statuses = new string[numberOfPersons];

        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.Write("Enter height (in meters) for person " + (i + 1) + ": ");
            heights[i] = double.Parse(Console.ReadLine());
            Console.Write("Enter weight (in kilograms) for person " + (i + 1) + ": ");
            weights[i] = double.Parse(Console.ReadLine());

            bmis[i] = weights[i] / (heights[i] * heights[i]);

            if (bmis[i] <= 18.4)
                statuses[i] = "Underweight";
            else if (bmis[i] <= 24.9)
                statuses[i] = "Normal";
            else if (bmis[i] <= 39.9)
                statuses[i] = "Overweight";
            else
                statuses[i] = "Obese";
        }

        Console.WriteLine("\nResults:");
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine("Person " + (i + 1) + ": Height = " + heights[i].ToString("0.00") +
                              " m, Weight = " + weights[i].ToString("0.00") + " kg, BMI = " +
                              bmis[i].ToString("0.00") + ", Status = " + statuses[i]);
        }
    }
}
