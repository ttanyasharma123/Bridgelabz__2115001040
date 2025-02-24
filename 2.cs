
using System;
using System.Reflection;

class Person
{
    private int age = 25; // Private field

    public void DisplayAge()
    {
        Console.WriteLine($"Age: {age}");
    }
}

class Program
{
    static void Main()
    {
        Person person = new Person();

        // Step 1: Get the Type of the class
        Type type = typeof(Person);

        // Step 2: Get the private field "age" using Reflection
        FieldInfo field = type.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);

        if (field != null)
        {
            // Step 3: Retrieve the current value of the private field
            Console.WriteLine($"Original Age: {field.GetValue(person)}");

            // Step 4: Modify the private field value
            field.SetValue(person, 30);

            // Step 5: Retrieve the modified value
            Console.WriteLine($"Modified Age: {field.GetValue(person)}");

            // Verify by calling a method
            person.DisplayAge();
        }
        else
        {
            Console.WriteLine("Field not found.");
        }
    }
}
