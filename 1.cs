using System;

class Program
{
    static void Main()
    {
        int[] ages = new int[10];
        for (int i = 0; i < ages.Length; i++)
        {
            Console.Write("Enter age of student {0}: ", i + 1);
            ages[i] = int.Parse(Console.ReadLine());
        }

        foreach (int age in ages)
        {
            if (age < 0)
            {
                Console.WriteLine("Invalid age");
            }
            else if (age >= 18)
            {
                Console.WriteLine("The student with the age {0} can vote.", age);
            }
            else
            {
                Console.WriteLine("The student with the age {0} cannot vote.", age);
            }
        }
    }
}
