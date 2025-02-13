using System;
using System.Collections.Generic;

class StockSpan
{
    // Function to calculate stock span
    static void CalculateSpan(int[] prices, int[] span)
    {
        Stack<int> stack = new Stack<int>();
        span[0] = 1;
        stack.Push(0);
        
        for (int i = 1; i < prices.Length; i++)
        {
            while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
            {
                stack.Pop();
            }
            
            span[i] = (stack.Count == 0) ? (i + 1) : (i - stack.Peek());
            stack.Push(i);
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        int[] prices = {100, 80, 60, 70, 60, 75, 85};
        int[] span = new int[prices.Length];
        
        CalculateSpan(prices, span);
        
        Console.WriteLine("Stock Span:");
        PrintArray(span);
    }
}
