using System;

class RocketLaunch
{
    static void Main(string[] args)
    {
        Console.Write("Enter the countdown starting value: ");
        int counter = int.Parse(Console.ReadLine());

        while (counter >= 1)
        {
            Console.WriteLine(counter);
            counter--;
        }

        Console.WriteLine("Rocket Launched!");
    }
}
