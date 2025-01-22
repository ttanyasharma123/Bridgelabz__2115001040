using System;

class EarthVolume
{
    static void Main()
    {
        double radiusKm = 6378;
        double pi = Math.PI;
        double volumeKm = (4.0 / 3) * pi * Math.Pow(radiusKm, 3);
        double volumeMiles = volumeKm / Math.Pow(1.6, 3);

        Console.WriteLine("The volume of earth in cubic kilometers is {volumeKm:F2} and cubic miles is {volumeMiles:F2}");
    }
}

