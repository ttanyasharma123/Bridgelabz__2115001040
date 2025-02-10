using System;

// Abstract Class
abstract class Vehicle
{
    protected int vehicleId;
    protected string driverName;
    protected double ratePerKm;

    public Vehicle(int id, string name, double rate)
    {
        this.vehicleId = id;
        this.driverName = name;
        this.ratePerKm = rate;
    }

    public abstract double CalculateFare(double distance);

    public void GetVehicleDetails()
    {
        Console.WriteLine(string.Format("Vehicle ID: {0}, Driver: {1}, Rate per Km: {2}", vehicleId, driverName, ratePerKm));
    }
}

// Interface for GPS Functionality
interface IGPS
{
    void GetCurrentLocation();
    void UpdateLocation(string newLocation);
}

// Car Class
class Car : Vehicle, IGPS
{
    private string location;

    public Car(int id, string name, double rate) : base(id, name, rate)
    {
        this.location = "Unknown";
    }

    public override double CalculateFare(double distance)
    {
        return ratePerKm * distance;
    }

    public void GetCurrentLocation()
    {
        Console.WriteLine("Car Current Location: " + location);
    }

    public void UpdateLocation(string newLocation)
    {
        this.location = newLocation;
        Console.WriteLine("Car Location Updated to: " + newLocation);
    }
}

// Bike Class
class Bike : Vehicle, IGPS
{
    private string location;

    public Bike(int id, string name, double rate) : base(id, name, rate)
    {
        this.location = "Unknown";
    }

    public override double CalculateFare(double distance)
    {
        return ratePerKm * distance;
    }

    public void GetCurrentLocation()
    {
        Console.WriteLine("Bike Current Location: " + location);
    }

    public void UpdateLocation(string newLocation)
    {
        this.location = newLocation;
        Console.WriteLine("Bike Location Updated to: " + newLocation);
    }
}

// Auto Class
class Auto : Vehicle, IGPS
{
    private string location;

    public Auto(int id, string name, double rate) : base(id, name, rate)
    {
        this.location = "Unknown";
    }

    public override double CalculateFare(double distance)
    {
        return ratePerKm * distance;
    }

    public void GetCurrentLocation()
    {
        Console.WriteLine("Auto Current Location: " + location);
    }

    public void UpdateLocation(string newLocation)
    {
        this.location = newLocation;
        Console.WriteLine("Auto Location Updated to: " + newLocation);
    }
}

// Main Program - Only One Main() to Avoid Conflicts
class RideHailingApp  // Renamed from Program
{
    static void Main()
    {
        // Using Polymorphism with Vehicle reference
        Vehicle vehicle1 = new Car(101, "John Doe", 10.0);
        vehicle1.GetVehicleDetails();
        Console.WriteLine("Total Fare: " + vehicle1.CalculateFare(15)); // Example: 15 km ride

        Car car = (Car)vehicle1;
        car.GetCurrentLocation();
        car.UpdateLocation("Downtown");

        Vehicle vehicle2 = new Bike(102, "Jane Smith", 5.0);
        vehicle2.GetVehicleDetails();
        Console.WriteLine("Total Fare: " + vehicle2.CalculateFare(10)); // Example: 10 km ride

        Bike bike = (Bike)vehicle2;
        bike.GetCurrentLocation();
        bike.UpdateLocation("City Center");

        Vehicle vehicle3 = new Auto(103, "Mike Brown", 7.0);
        vehicle3.GetVehicleDetails();
        Console.WriteLine("Total Fare: " + vehicle3.CalculateFare(8)); // Example: 8 km ride

        Auto auto = (Auto)vehicle3;
        auto.GetCurrentLocation();
        auto.UpdateLocation("Market Square");
    }
}
