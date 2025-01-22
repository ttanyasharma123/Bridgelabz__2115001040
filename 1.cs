using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("Enter the first number: ");
        string input1 = Console.ReadLine();
        int number1;

        
        if (!int.TryParse(input1, out number1))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return;
        }

        
        Console.Write("Enter the second number: ");
        string input2 = Console.ReadLine();
        int number2;

        
        if (!int.TryParse(input2, out number2))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return;
        }

        
        if (number2 == 0)
        {
            Console.WriteLine("Division by zero is not allowed.");
            return;
        }

        
        int quotient = number1 / number2;
        int remainder = number1 % number2;

        
        Console.WriteLine("The Quotient is {0} and Remainder is {1} of two numbers {2} and {3}.", quotient, remainder, number1, number2);
    }
}
