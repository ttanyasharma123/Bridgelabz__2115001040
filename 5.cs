using System;

// Base class: Device
class Device
{
    public int DeviceId { get; set; }
    public string Status { get; set; }

    public Device(int deviceId, string status)
    {
        DeviceId = deviceId;
        Status = status;
    }

    // Virtual method to be overridden by subclass
    public virtual void DisplayStatus()
    {
        Console.WriteLine($"Device ID: {DeviceId}, Status: {Status}");
    }
}

// Subclass: Thermostat
class Thermostat : Device
{
    public double TemperatureSetting { get; set; }

    public Thermostat(int deviceId, string status, double temperatureSetting) : base(deviceId, status)
    {
        TemperatureSetting = temperatureSetting;
    }

    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine($"Temperature Setting: {TemperatureSetting}°C");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Thermostat myThermostat = new Thermostat(101, "On", 22.5);
        myThermostat.DisplayStatus();
    }
}
