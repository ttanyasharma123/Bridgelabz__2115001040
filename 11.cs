using System;

// Superclass: Vehicle
class Vehicle
{
    public int MaxSpeed { get; set; }
    public string Model { get; set; }

    public Vehicle(int maxSpeed, string model)
    {
        MaxSpeed = maxSpeed;
        Model = model;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Model: {Model}, Max Speed: {MaxSpeed} km/h");
    }
}

// Interface: Refuelable (For petrol vehicles)
interface Refuelable
{
    void Refuel();
}

// Subclass: ElectricVehicle (Inherits from Vehicle)
class ElectricVehicle : Vehicle
{
    public int BatteryCapacity { get; set; }

    public ElectricVehicle(int maxSpeed, string model, int batteryCapacity)
        : base(maxSpeed, model)
    {
        BatteryCapacity = batteryCapacity;
    }

    public void Charge()
    {
        Console.WriteLine($"{Model} (Electric Vehicle) is charging. Battery Capacity: {BatteryCapacity} kWh.");
    }
}

// Subclass: PetrolVehicle (Inherits from Vehicle & Implements Refuelable)
class PetrolVehicle : Vehicle, Refuelable
{
    public int FuelCapacity { get; set; }

    public PetrolVehicle(int maxSpeed, string model, int fuelCapacity)
        : base(maxSpeed, model)
    {
        FuelCapacity = fuelCapacity;
    }

    public void Refuel()
    {
        Console.WriteLine($"{Model} (Petrol Vehicle) is refueling. Fuel Capacity: {FuelCapacity} liters.");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        ElectricVehicle tesla = new ElectricVehicle(200, "Tesla Model S", 100);
        PetrolVehicle mustang = new PetrolVehicle(250, "Ford Mustang", 60);

        tesla.DisplayInfo();
        tesla.Charge();

        mustang.DisplayInfo();
        mustang.Refuel();
    }
}
