using System;

class BMIProgram
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of persons: ");
        int numberOfPersons = int.Parse(Console.ReadLine());

        double[][] personData = new double[numberOfPersons][];
        string[] weightStatus = new string[numberOfPersons];

        for (int i = 0; i < numberOfPersons; i++)
        {
            personData[i] = new double[3];

            do
            {
                Console.Write("Enter height (in meters) for person " + (i + 1) + ": ");
                personData[i][0] = double.Parse(Console.ReadLine());
                if (personData[i][0] <= 0)
                    Console.WriteLine("Height must be positive. Please re-enter.");
            } while (personData[i][0] <= 0);

            do
            {
                Console.Write("Enter weight (in kilograms) for person " + (i + 1) + ": ");
                personData[i][1] = double.Parse(Console.ReadLine());
                if (personData[i][1] <= 0)
                    Console.WriteLine("Weight must be positive. Please re-enter.");
            } while (personData[i][1] <= 0);

            personData[i][2] = personData[i][1] / (personData[i][0] * personData[i][0]);

            if (personData[i][2] <= 18.4)
                weightStatus[i] = "Underweight";
            else if (personData[i][2] <= 24.9)
                weightStatus[i] = "Normal";
            else if (personData[i][2] <= 39.9)
                weightStatus[i] = "Overweight";
            else
                weightStatus[i] = "Obese";
        }

        Console.WriteLine("\nResults:");
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine("Person " + (i + 1) + ": Height = " + personData[i][0].ToString("0.00") +
                              " m, Weight = " + personData[i][1].ToString("0.00") + " kg, BMI = " +
                              personData[i][2].ToString("0.00") + ", Status = " + weightStatus[i]);
        }
    }
}
