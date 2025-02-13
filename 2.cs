using System;
using System.Collections.Generic;

class SortStack
{
    // Function to sort the stack recursively
    static void Sort(Stack<int> stack)
    {
        if (stack.Count > 0)
        {
            // Pop the top element
            int top = stack.Pop();

            // Recursively sort the remaining stack
            Sort(stack);

            // Insert the popped element at the correct position
            Insert(stack, top);
        }
    }

    // Function to insert an element in a sorted stack
    static void Insert(Stack<int> stack, int element)
    {
        if (stack.Count == 0 || stack.Peek() <= element)
        {
            stack.Push(element);
        }
        else
        {
            // Remove the top element
            int top = stack.Pop();

            // Recursively insert the element
            Insert(stack, element);

            // Push the removed element back
            stack.Push(top);
        }
    }

    static void PrintStack(Stack<int> stack)
    {
        foreach (int item in stack)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(3);
        stack.Push(1);
        stack.Push(4);
        stack.Push(2);
        stack.Push(5);

        Console.WriteLine("Original Stack:");
        PrintStack(stack);

        Sort(stack);

        Console.WriteLine("Sorted Stack:");
        PrintStack(stack);
    }
}
