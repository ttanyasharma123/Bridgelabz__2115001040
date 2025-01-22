using System;

class DiscountInput
{
    static void Main()
    {
        Console.Write("Enter the fee amount (INR): ");
        double fee = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the discount percentage: ");
        double discountPercent = Convert.ToDouble(Console.ReadLine());

        double discount = fee * (discountPercent / 100);
        double finalFee = fee - discount;

        Console.WriteLine("The discount amount is INR {discount:F2} and final discounted fee is INR {finalFee:F2}");
    }
}


