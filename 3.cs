using System;
using System.Collections.Generic;

// Abstract class Vehicle
abstract class Vehicle
{
    protected string vehicleNumber;
    protected string type;
    protected double rentalRate;

    public Vehicle(string vehicleNumber, string type, double rentalRate)
    {
        this.vehicleNumber = vehicleNumber;
        this.type = type;
        this.rentalRate = rentalRate;
    }

    public abstract double CalculateRentalCost(int days);

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Vehicle Number: {vehicleNumber}, Type: {type}, Rental Rate: {rentalRate:C}");
    }
}

// Interface IInsurable
interface IInsurable
{
    double CalculateInsurance();
    string GetInsuranceDetails();
}

// Car class
class Car : Vehicle, IInsurable
{
    private string insurancePolicyNumber;

    public Car(string vehicleNumber, double rentalRate, string insurancePolicyNumber)
        : base(vehicleNumber, "Car", rentalRate)
    {
        this.insurancePolicyNumber = insurancePolicyNumber;
    }

    public override double CalculateRentalCost(int days)
    {
        return rentalRate * days;
    }

    public double CalculateInsurance()
    {
        return rentalRate * 0.10; // 10% insurance
    }

    public string GetInsuranceDetails()
    {
        return "Car insurance is calculated at 10%.";
    }
}

// Bike class
class Bike : Vehicle
{
    public Bike(string vehicleNumber, double rentalRate)
        : base(vehicleNumber, "Bike", rentalRate) { }

    public override double CalculateRentalCost(int days)
    {
        return rentalRate * days;
    }
}

// Truck class
class Truck : Vehicle, IInsurable
{
    private string insurancePolicyNumber;

    public Truck(string vehicleNumber, double rentalRate, string insurancePolicyNumber)
        : base(vehicleNumber, "Truck", rentalRate)
    {
        this.insurancePolicyNumber = insurancePolicyNumber;
    }

    public override double CalculateRentalCost(int days)
    {
        return rentalRate * days * 1.2; // 20% extra charge for trucks
    }

    public double CalculateInsurance()
    {
        return rentalRate * 0.15; // 15% insurance
    }

    public string GetInsuranceDetails()
    {
        return "Truck insurance is calculated at 15%.";
    }
}

// Main program
class Program
{
    static void CalculateCosts(List<Vehicle> vehicles, int days)
    {
        foreach (var vehicle in vehicles)
        {
            double rentalCost = vehicle.CalculateRentalCost(days);
            double insuranceCost = (vehicle is IInsurable insurableVehicle) ? insurableVehicle.CalculateInsurance() : 0;

            vehicle.DisplayDetails();
            Console.WriteLine($"Rental Cost for {days} days: {rentalCost:C}, Insurance Cost: {insuranceCost:C}\n");
        }
    }

    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car("A123", 1000, "INS123"),
            new Bike("B456", 500),
            new Truck("C789", 2000, "INS789")
        };

        CalculateCosts(vehicles, 5);
    }
}
