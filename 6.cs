using System;

class ProcessNode
{
    public int ProcessID;
    public int BurstTime;
    public int Priority;
    public ProcessNode Next;

    public ProcessNode(int processID, int burstTime, int priority)
    {
        ProcessID = processID;
        BurstTime = burstTime;
        Priority = priority;
        Next = null;
    }
}

class RoundRobinScheduler
{
    private ProcessNode head = null;
    private ProcessNode tail = null;
    private int timeQuantum;

    public RoundRobinScheduler(int quantum)
    {
        timeQuantum = quantum;
    }

    public void AddProcess(int processID, int burstTime, int priority)
    {
        ProcessNode newProcess = new ProcessNode(processID, burstTime, priority);
        if (head == null)
        {
            head = newProcess;
            tail = newProcess;
            newProcess.Next = head;
        }
        else
        {
            tail.Next = newProcess;
            tail = newProcess;
            tail.Next = head;
        }
    }

    public void RemoveProcess(int processID)
    {
        if (head == null) return;

        ProcessNode temp = head, prev = null;
        do
        {
            if (temp.ProcessID == processID)
            {
                if (temp == head && temp == tail)
                {
                    head = tail = null;
                }
                else if (temp == head)
                {
                    tail.Next = head.Next;
                    head = head.Next;
                }
                else
                {
                    prev.Next = temp.Next;
                    if (temp == tail) tail = prev;
                }
                return;
            }
            prev = temp;
            temp = temp.Next;
        } while (temp != head);
    }

    public void SimulateScheduling()
    {
        if (head == null) return;

        int totalWaitingTime = 0, totalTurnAroundTime = 0, processCount = 0;
        ProcessNode current = head;
        int currentTime = 0;

        while (head != null)
        {
            processCount++;
            Console.WriteLine($"Executing Process {current.ProcessID} with Burst Time {current.BurstTime}");

            if (current.BurstTime > timeQuantum)
            {
                current.BurstTime -= timeQuantum;
                currentTime += timeQuantum;
                tail = current;
                current = current.Next;
            }
            else
            {
                currentTime += current.BurstTime;
                totalTurnAroundTime += currentTime;
                totalWaitingTime += currentTime - current.BurstTime;
                int completedProcessID = current.ProcessID;
                current = current.Next;
                RemoveProcess(completedProcessID);
                if (current == null) break;
            }
            DisplayProcesses();
        }

        Console.WriteLine($"Average Waiting Time: {(double)totalWaitingTime / processCount}");
        Console.WriteLine($"Average Turn-Around Time: {(double)totalTurnAroundTime / processCount}");
    }

    public void DisplayProcesses()
    {
        if (head == null)
        {
            Console.WriteLine("No processes in the queue.");
            return;
        }
        ProcessNode temp = head;
        Console.Write("Processes in queue: ");
        do
        {
            Console.Write($"[PID {temp.ProcessID}, BT {temp.BurstTime}] -> ");
            temp = temp.Next;
        } while (temp != head);
        Console.WriteLine("(Back to Head)");
    }
}

class Program
{
    static void Main()
    {
        RoundRobinScheduler scheduler = new RoundRobinScheduler(3);
        scheduler.AddProcess(1, 10, 1);
        scheduler.AddProcess(2, 5, 2);
        scheduler.AddProcess(3, 8, 1);

        Console.WriteLine("Initial Process Queue:");
        scheduler.DisplayProcesses();

        Console.WriteLine("\nSimulating Round Robin Scheduling:");
        scheduler.SimulateScheduling();
    }
}
