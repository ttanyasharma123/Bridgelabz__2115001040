using System;

class ChocolateDivision
{
    static void Main()
    {
        
        int numberOfChocolates, numberOfChildren;

        
        Console.Write("Enter the number of chocolates: ");
        numberOfChocolates = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of children: ");
        numberOfChildren = int.Parse(Console.ReadLine());

       
        int chocolatesPerChild = numberOfChocolates / numberOfChildren;
        int remainingChocolates = numberOfChocolates % numberOfChildren;

        
        Console.WriteLine("The number of chocolates each child gets is {0} and the number of remaining chocolates is {1}.", chocolatesPerChild, remainingChocolates);
    }
}
