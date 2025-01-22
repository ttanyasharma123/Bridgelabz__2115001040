using System;

class ProfitCalculation
{
    static void Main()
    {
        int costPrice = 129;
        int sellingPrice = 191;
        int profit = sellingPrice - costPrice;
        double profitPercent = (profit / (double)costPrice) * 100;

        Console.WriteLine("The Cost Price is INR {costPrice} and Selling Price is INR {sellingPrice}\n" +
                          "The Profit is INR {profit} and the Profit Percentage is {profitPercent:F2}%");
    }
}

