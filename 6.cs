using System;
using System.Collections.Generic;
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
        // Create a list of Car objects
        List<Car> cars = new List<Car>
        {
            new Car { Brand = "Toyota", Model = "Camry", Year = 2022 },
            new Car { Brand = "Honda", Model = "Civic", Year = 2021 },
            new Car { Brand = "Ford", Model = "Mustang", Year = 2023 }
        };

        // Convert the list into a JSON array
        string jsonArray = JsonConvert.SerializeObject(cars, Formatting.Indented);

        // Print the JSON output
        Console.WriteLine("JSON Array:");
        Console.WriteLine(jsonArray);
    }
}
