using System;
using System.Collections.Generic;

class Program
{
    static string FindNthFromEnd(LinkedList<string> list, int N)
    {
        LinkedListNode<string> fast = list.First;
        LinkedListNode<string> slow = list.First;

        // Move the fast pointer N steps ahead
        for (int i = 0; i < N; i++)
        {
            if (fast == null) return "Invalid N"; // If N is greater than list size
            fast = fast.Next;
        }

        // Move both pointers one step at a time
        while (fast != null)
        {
            fast = fast.Next;
            slow = slow.Next;
        }

        return slow.Value;
    }

    static void Main()
    {
        LinkedList<string> list = new LinkedList<string>(new string[] { "A", "B", "C", "D", "E" });
        int N = 2;

        Console.WriteLine($"Nth element from the end: {FindNthFromEnd(list, N)}");
    }
}
