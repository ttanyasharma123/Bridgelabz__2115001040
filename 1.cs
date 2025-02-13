using System;

class QueueUsingStacks
{
    private int[] stack1; // Stack for enqueue
    private int[] stack2; // Stack for dequeue
    private int top1, top2;
    private int size;

    public QueueUsingStacks(int size)
    {
        this.size = size;
        stack1 = new int[size];
        stack2 = new int[size];
        top1 = -1;
        top2 = -1;
    }

    // Enqueue operation
    public void Enqueue(int data)
    {
        if (top1 == size - 1)
        {
            Console.WriteLine("Queue is full");
            return;
        }
        stack1[++top1] = data; // Push to stack1
    }

    // Dequeue operation
    public int Dequeue()
    {
        if (top2 == -1)
        {
            if (top1 == -1)
            {
                Console.WriteLine("Queue is empty");
                return -1;
            }
            while (top1 != -1)
            {
                stack2[++top2] = stack1[top1--]; // Transfer elements
            }
        }
        return stack2[top2--]; // Pop from stack2
    }

    // Display elements (from stack2 first, then stack1)
    public void Display()
    {
        if (top1 == -1 && top2 == -1)
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        Console.Write("Queue: ");
        for (int i = top2; i >= 0; i--)
        {
            Console.Write(stack2[i] + " ");
        }
        for (int i = 0; i <= top1; i++)
        {
            Console.Write(stack1[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        QueueUsingStacks q = new QueueUsingStacks(5);
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        q.Display();

        Console.WriteLine("Dequeued: " + q.Dequeue());
        q.Display();

        q.Enqueue(4);
        q.Enqueue(5);
        q.Enqueue(6); // This should print "Queue is full"
        q.Display();

        Console.WriteLine("Dequeued: " + q.Dequeue());
        Console.WriteLine("Dequeued: " + q.Dequeue());
        q.Display();
    }
}
