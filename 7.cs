using System;
using System.Reflection;

class Configuration
{
    // Private static field
    private static string API_KEY = "DefaultAPIKey";

    // Public method to display the API_KEY
    public static void ShowAPIKey()
    {
        Console.WriteLine($"API_KEY: {API_KEY}");
    }
}

class Program
{
    static void Main()
    {
        // Get the type of Configuration class
        Type type = typeof(Configuration);

        // Retrieve the private static field "API_KEY" using Reflection
        FieldInfo field = type.GetField("API_KEY", BindingFlags.NonPublic | BindingFlags.Static);

        if (field != null)
        {
            Console.WriteLine("Before Modification:");
            Configuration.ShowAPIKey();

            // Modify the private static field value
            field.SetValue(null, "NewSecretAPIKey");

            Console.WriteLine("After Modification:");
            Configuration.ShowAPIKey();
        }
        else
        {
            Console.WriteLine("Field not found!");
        }
    }
}

