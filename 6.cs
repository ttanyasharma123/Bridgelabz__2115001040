using System;
using System.Reflection;

// Step 1: Define a custom attribute
[AttributeUsage(AttributeTargets.Class)] // Apply only to classes
class AuthorAttribute : Attribute
{
    public string Name { get; }

    public AuthorAttribute(string name)
    {
        Name = name;
    }
}

// Step 2: Apply the custom attribute to a class
[Author("Tanya Sharma")]
class SampleClass
{
    public void Display()
    {
        Console.WriteLine("SampleClass method executed.");
    }
}

class Program
{
    static void Main()
    {
        // Step 3: Get the type of SampleClass
        Type type = typeof(SampleClass);

        // Step 4: Retrieve the custom attribute using Reflection
        object[] attributes = type.GetCustomAttributes(typeof(AuthorAttribute), false);

        // Check if attribute exists
        if (attributes.Length > 0)
        {
            // Cast the attribute to AuthorAttribute and display the author's name
            AuthorAttribute author = (AuthorAttribute)attributes[0];
            Console.WriteLine($"Author: {author.Name}");
        }
        else
        {
            Console.WriteLine("No Author attribute found.");
        }
    }
}


