using System;

class TotalPurchase
{
    static void Main()
    {
       
        Console.WriteLine("Enter the unit price of the item:");
        double unitPrice = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the quantity to be bought:");
        int quantity = Convert.ToInt32(Console.ReadLine());

        
        double totalPrice = unitPrice * quantity;

      
        Console.WriteLine("The total purchase price is INR " + totalPrice + " if the quantity " + quantity + " and unit price is INR " + unitPrice);
    }
}
