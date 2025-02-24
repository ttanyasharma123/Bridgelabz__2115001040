using System;
using System.Collections.Generic;
using System.Reflection;

class ObjectMapper
{
    public static T ToObject<T>(Type clazz, Dictionary<string, object> properties) where T : new()
    {
        // Create an instance of the given type
        T obj = (T)Activator.CreateInstance(clazz);

        // Get all fields (private and public) from the class
        FieldInfo[] fields = clazz.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var field in fields)
        {
            // Check if dictionary contains the field name
            if (properties.ContainsKey(field.Name))
            {
                // Set the field value dynamically
                field.SetValue(obj, Convert.ChangeType(properties[field.Name], field.FieldType));
            }
        }

        return obj;
    }
}

// Sample class to test the ObjectMapper
class Student
{
    public string Name;
    private int Age; // Private field to test Reflection access

    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

class Program
{
    static void Main()
    {
        // Define dictionary with field values
        Dictionary<string, object> studentData = new Dictionary<string, object>
        {
            { "Name", "Tanya" },
            { "Age", 21 }
        };

        // Create Student object using ToObject
        Student student = ObjectMapper.ToObject<Student>(typeof(Student), studentData);

        // Display the mapped values
        student.Display();
    }
}


