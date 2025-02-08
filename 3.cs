using System;

// Base class: Vehicle
class Vehicle
{
    public int MaxSpeed { get; set; }
    public string FuelType { get; set; }

    public Vehicle(int maxSpeed, string fuelType)
    {
        MaxSpeed = maxSpeed;
        FuelType = fuelType;
    }

    // Virtual method to be overridden by subclasses
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Max Speed: {MaxSpeed} km/h, Fuel Type: {FuelType}");
    }
}

// Subclass: Car
class Car : Vehicle
{
    public int SeatCapacity { get; set; }

    public Car(int maxSpeed, string fuelType, int seatCapacity) : base(maxSpeed, fuelType)
    {
        SeatCapacity = seatCapacity;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Seat Capacity: {SeatCapacity}");
    }
}

// Subclass: Truck
class Truck : Vehicle
{
    public int PayloadCapacity { get; set; }

    public Truck(int maxSpeed, string fuelType, int payloadCapacity) : base(maxSpeed, fuelType)
    {
        PayloadCapacity = payloadCapacity;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Payload Capacity: {PayloadCapacity} kg");
    }
}

// Subclass: Motorcycle
class Motorcycle : Vehicle
{
    public bool HasSidecar { get; set; }

    public Motorcycle(int maxSpeed, string fuelType, bool hasSidecar) : base(maxSpeed, fuelType)
    {
        HasSidecar = hasSidecar;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Has Sidecar: {HasSidecar}");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Vehicle[] vehicles = new Vehicle[]
        {
            new Car(200, "Petrol", 5),
            new Truck(120, "Diesel", 10000),
            new Motorcycle(180, "Petrol", true)
        };

        foreach (var vehicle in vehicles)
        {
            vehicle.DisplayInfo();
            Console.WriteLine();
        }
    }
}