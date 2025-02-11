using System;

class TaskNode
{
    public int TaskID;
    public string TaskName;
    public int Priority;
    public DateTime DueDate;
    public TaskNode Next;

    public TaskNode(int taskID, string taskName, int priority, DateTime dueDate)
    {
        TaskID = taskID;
        TaskName = taskName;
        Priority = priority;
        DueDate = dueDate;
        Next = null;
    }
}

class CircularTaskScheduler
{
    private TaskNode head = null;
    private TaskNode current = null;

    public void AddTask(int taskID, string taskName, int priority, DateTime dueDate, int position = -1)
    {
        TaskNode newTask = new TaskNode(taskID, taskName, priority, dueDate);

        if (head == null)
        {
            head = newTask;
            head.Next = head;
            return;
        }

        TaskNode temp = head;
        if (position == 0) // Add at the beginning
        {
            while (temp.Next != head) temp = temp.Next;
            newTask.Next = head;
            head = newTask;
            temp.Next = head;
        }
        else if (position == -1) // Add at the end
        {
            while (temp.Next != head) temp = temp.Next;
            temp.Next = newTask;
            newTask.Next = head;
        }
        else // Add at a specific position
        {
            for (int i = 0; i < position - 1 && temp.Next != head; i++)
                temp = temp.Next;
            newTask.Next = temp.Next;
            temp.Next = newTask;
        }
    }

    public void RemoveTask(int taskID)
    {
        if (head == null) return;

        TaskNode temp = head, prev = null;
        do
        {
            if (temp.TaskID == taskID)
            {
                if (temp == head)
                {
                    TaskNode last = head;
                    while (last.Next != head) last = last.Next;
                    head = head.Next;
                    last.Next = head;
                }
                else
                {
                    prev.Next = temp.Next;
                }
                return;
            }
            prev = temp;
            temp = temp.Next;
        } while (temp != head);
    }

    public void ViewCurrentTask()
    {
        if (current == null) current = head;
        if (current != null)
        {
            Console.WriteLine($"Task ID: {current.TaskID}, Name: {current.TaskName}, Priority: {current.Priority}, Due Date: {current.DueDate}");
            current = current.Next;
        }
    }

    public void DisplayAllTasks()
    {
        if (head == null) return;
        TaskNode temp = head;
        do
        {
            Console.WriteLine($"Task ID: {temp.TaskID}, Name: {temp.TaskName}, Priority: {temp.Priority}, Due Date: {temp.DueDate}");
            temp = temp.Next;
        } while (temp != head);
    }

    public void SearchByPriority(int priority)
    {
        if (head == null) return;
        TaskNode temp = head;
        bool found = false;
        do
        {
            if (temp.Priority == priority)
            {
                Console.WriteLine($"Task ID: {temp.TaskID}, Name: {temp.TaskName}, Priority: {temp.Priority}, Due Date: {temp.DueDate}");
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);
        if (!found) Console.WriteLine("No tasks found with the given priority.");
    }
}

class Program
{
    static void Main()
    {
        CircularTaskScheduler scheduler = new CircularTaskScheduler();
        scheduler.AddTask(1, "Task A", 2, DateTime.Now.AddDays(2));
        scheduler.AddTask(2, "Task B", 1, DateTime.Now.AddDays(3));
        scheduler.AddTask(3, "Task C", 3, DateTime.Now.AddDays(1), 0);

        Console.WriteLine("All Tasks:");
        scheduler.DisplayAllTasks();

        Console.WriteLine("\nViewing Current Task:");
        scheduler.ViewCurrentTask();

        Console.WriteLine("\nSearching for Priority 2:");
        scheduler.SearchByPriority(2);

        Console.WriteLine("\nRemoving Task ID 2:");
        scheduler.RemoveTask(2);
        scheduler.DisplayAllTasks();
    }
}