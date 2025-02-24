using System;
using System.Reflection;

class SampleClass
{
    public int Id;
    public string Name;

    public SampleClass() { }
    public SampleClass(int id, string name) { Id = id; Name = name; }

    public void Display() { Console.WriteLine($"ID: {Id}, Name: {Name}"); }
    private void SecretMethod() { Console.WriteLine("This is a private method."); }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter class name (e.g., SampleClass): ");
        string className = Console.ReadLine();

        Type type = Type.GetType(className);
        if (type == null)
        {
            Console.WriteLine("Class not found.");
            return;
        }

        Console.WriteLine($"\nClass: {type.Name}");
        
        // Display Fields
        Console.WriteLine("\nFields:");
        FieldInfo[] fields = type.GetFields();
        foreach (var field in fields)
        {
            Console.WriteLine($"- {field.FieldType} {field.Name}");
        }

        // Display Methods
        Console.WriteLine("\nMethods:");
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        foreach (var method in methods)
        {
            Console.WriteLine($"- {method.ReturnType} {method.Name}()");
        }

        // Display Constructors
        Console.WriteLine("\nConstructors:");
        ConstructorInfo[] constructors = type.GetConstructors();
        foreach (var constructor in constructors)
        {
            Console.WriteLine($"- {constructor}");
        }
    }
}
