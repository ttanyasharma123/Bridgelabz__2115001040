using System;

// Custom Exception Class
class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message) { }
}

class Program
{
    // Method to validate age
    static void ValidateAge(int age)
    {
        if (age < 18)
        {
            throw new InvalidAgeException("Age must be 18 or above.");
        }
        Console.WriteLine("Access granted!");
    }

    static void Main()
    {
        try
        {
            // Taking user input
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            // Validating age
            ValidateAge(age);
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid numeric age.");
        }
        finally
        {
            Console.WriteLine("Program execution completed.");
        }
    }
}
