using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

class JsonConverter
{
    public static string ToJson(object obj)
    {
        if (obj == null) return "{}";

        Type type = obj.GetType();
        StringBuilder json = new StringBuilder();
        json.Append("{");

        // Get all fields (public & private)
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        List<string> fieldPairs = new List<string>();

        foreach (var field in fields)
        {
            object value = field.GetValue(obj);
            string formattedValue = FormatValue(value);
            fieldPairs.Add($"\"{field.Name}\": {formattedValue}");
        }

        json.Append(string.Join(", ", fieldPairs));
        json.Append("}");

        return json.ToString();
    }

    private static string FormatValue(object value)
    {
        if (value == null)
            return "null";

        if (value is string)
            return $"\"{value}\""; // Add quotes around strings

        if (value is bool)
            return value.ToString().ToLower(); // Convert bool to lowercase

        return value.ToString(); // Default: numbers, etc.
    }
}

// Sample class for testing
class Person
{
    public string Name = "Tanya";
    private int Age = 21;
    public bool IsStudent = true;
}

class Program
{
    static void Main()
    {
        Person person = new Person();
        string json = JsonConverter.ToJson(person);
        Console.WriteLine(json);
    }
}
