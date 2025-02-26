using System;
using Newtonsoft.Json; 

class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}

class Program
{
    static void Main()
    {
        // Creating a Car object
        Car myCar = new Car
        {
            Brand = "Toyota",
            Model = "Camry",
            Year = 2022
        };

        // Convert Car object to JSON
        string jsonString = JsonConvert.SerializeObject(myCar, Formatting.Indented);

        // Print the JSON string
        Console.WriteLine("Car Object in JSON Format:");
        Console.WriteLine(jsonString);
    }
}
