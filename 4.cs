using System;
using System.Reflection;

// Step 1: Define a custom attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
class TaskInfoAttribute : Attribute
{
    public int Priority { get; }
    public string AssignedTo { get; }

    public TaskInfoAttribute(int priority, string assignedTo)
    {
        Priority = priority;
        AssignedTo = assignedTo;
    }
}

// Step 2: Apply the attribute to a method
class TaskManager
{
    [TaskInfo(1, "Tanya")]
    public void CompleteTask()
    {
        Console.WriteLine("Task is being completed...");
    }
}

// Step 3: Use Reflection to retrieve attribute details
class Program
{
    static void Main()
    {
        Type type = typeof(TaskManager);
        MethodInfo method = type.GetMethod("CompleteTask");

        if (method.GetCustomAttribute(typeof(TaskInfoAttribute)) is TaskInfoAttribute attr)
        {
            Console.WriteLine($"Task Priority: {attr.Priority}");
            Console.WriteLine($"Assigned To: {attr.AssignedTo}");
        }
        
        // Calling the method
        TaskManager task = new TaskManager();
        task.CompleteTask();
    }
}


