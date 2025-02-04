using System;

class Vehicle
{
    // Static variable shared by all vehicles (Registration Fee)
    public static double RegistrationFee = 5000.0;

    // Readonly variable for Registration Number (Cannot be modified after assignment)
    public readonly string RegistrationNumber;

    // Instance variables
    public string OwnerName { get; private set; }
    public string VehicleType { get; private set; }

    // Constructor using 'this' to initialize variables
    public Vehicle(string registrationNumber, string ownerName, string vehicleType)
    {
        this.RegistrationNumber = registrationNumber;
        this.OwnerName = ownerName;
        this.VehicleType = vehicleType;
    }

    // Static method to update registration fee
    public static void UpdateRegistrationFee(double newFee)
    {
        RegistrationFee = newFee;
    }

    // Method to display vehicle details using 'is' operator
    public void DisplayVehicleDetails()
    {
        if (this is Vehicle)
        {
            Console.WriteLine("Registration Number: " + RegistrationNumber);
            Console.WriteLine("Owner Name: " + OwnerName);
            Console.WriteLine("Vehicle Type: " + VehicleType);
            Console.WriteLine("Registration Fee: $" + RegistrationFee);
            Console.WriteLine("--------------------------");
        }
    }
}

// Main class to test the Vehicle class
class Program
{
    static void Main()
    {
        // Creating Vehicle objects
        Vehicle vehicle1 = new Vehicle("KA01AB1234", "Akash", "Car");
        Vehicle vehicle2 = new Vehicle("DL02XY5678", "Deepak", "Bike");

        // Displaying vehicle details
        vehicle1.DisplayVehicleDetails();
        vehicle2.DisplayVehicleDetails();

        // Updating the registration fee
        Console.WriteLine("Updating Registration Fee to $6000...");
        Vehicle.UpdateRegistrationFee(6000.0);

        // Display updated vehicle details
        vehicle1.DisplayVehicleDetails();
        vehicle2.DisplayVehicleDetails();
    }
}
