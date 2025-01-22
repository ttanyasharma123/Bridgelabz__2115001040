using System;

class IntOperation
{
    static void Main()
    {
        
        int a, b, c;

        
        Console.Write("Enter value for a: ");
        a = int.Parse(Console.ReadLine());

        Console.Write("Enter value for b: ");
        b = int.Parse(Console.ReadLine());

        Console.Write("Enter value for c: ");
        c = int.Parse(Console.ReadLine());

        
        int result1 = a + b * c; 
        int result2 = a * b + c; 
        int result3 = c + a / b; 
        int result4 = a % b + c; 

        
        Console.WriteLine("The results of Int Operations are:");
        Console.WriteLine("a + b * c = " + result1);
        Console.WriteLine("a * b + c = " + result2);
        Console.WriteLine("c + a / b = " + result3);
        Console.WriteLine("a % b + c = " + result4);
    }
}
