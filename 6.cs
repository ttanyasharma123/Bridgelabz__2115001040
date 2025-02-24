using System;
using System.Reflection;

// Step 1: Define a custom attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
class ImportantMethodAttribute : Attribute
{
    public string Level { get; }

    public ImportantMethodAttribute(string level = "HIGH") // Default: HIGH
    {
        Level = level;
    }
}

// Step 2: Apply the attribute to multiple methods
class MyClass
{
    [ImportantMethod("HIGH")]
    public void CriticalFunction()
    {
        Console.WriteLine("Executing Critical Function...");
    }

    [ImportantMethod("MEDIUM")]
    public void SecondaryFunction()
    {
        Console.WriteLine("Executing Secondary Function...");
    }

    public void NormalFunction()
    {
        Console.WriteLine("Executing Normal Function...");
    }
}

// Step 3: Retrieve and print annotated methods using Reflection
class Program
{
    static void Main()
    {
        Type type = typeof(MyClass);
        MethodInfo[] methods = type.GetMethods();

        Console.WriteLine("Important Methods:");
        foreach (MethodInfo method in methods)
        {
            if (method.GetCustomAttribute(typeof(ImportantMethodAttribute)) is ImportantMethodAttribute attr)
            {
                Console.WriteLine($"- {method.Name} (Level: {attr.Level})");
            }
        }
        
        // Calling the methods
        MyClass obj = new MyClass();
        obj.CriticalFunction();
        obj.SecondaryFunction();
        obj.NormalFunction();
    }
}


