using System;

class Handshakes
{
    static void Main()
    {
        Console.Write("Enter the number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int handshakes = (n * (n - 1)) / 2;

        Console.WriteLine("The maximum number of handshakes is {handshakes}");
    }
}
