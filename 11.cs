using System;
using System.Collections.Generic;

class Program
{
    static Queue<int> ReverseQueue(Queue<int> queue)
    {
        Stack<int> stack = new Stack<int>();

        // Dequeue elements from the queue and push them onto the stack
        while (queue.Count > 0)
        {
            stack.Push(queue.Dequeue());
        }

        // Pop elements from the stack and enqueue them back into the queue
        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }

        return queue;
    }

    static void Main()
    {
        Queue<int> queue = new Queue<int>(new int[] { 10, 20, 30 });

        Console.WriteLine("Original Queue: [" + string.Join(", ", queue) + "]");

        Queue<int> reversedQueue = ReverseQueue(queue);

        Console.WriteLine("Reversed Queue: [" + string.Join(", ", reversedQueue) + "]");
    }
}
