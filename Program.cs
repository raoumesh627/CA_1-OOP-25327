using System;
using System.Collections.Generic;
using Bogus;

class ParkingGarage

{
    private const double MinFee = 2.00;
    private const double MaxCharge = 10.00;
    private double hourlyFee;
    private int totalCars;

    public double TotalReceipts { get; private set; }


    public ParkingGarage(double hourlyFee, int totalCars)
    {

        this.hourlyFee = hourlyFee;
        this.totalCars = totalCars;
        TotalReceipts = 0;
    }

    public double CalculateCharges(double hours)

    {
        if (hours <= 3)
        {
            return MinFee;
        }
        else
        {

            double fee = MinFee + ((Math.Ceiling(hours) - 3) * hourlyFee);
            return fee > MaxCharge ? MaxCharge : fee;
        }
    }

    public void ProcessCars()
    {
        var faker = new Faker();
        for (int i = 0; i < totalCars; i++)
            5
        {
            string registrationNumber = faker.Random.AlphaNumeric(7).ToLower();
            double hoursParked = faker.Random.Double(0, 24);
            double charge = CalculateCharges(hoursParked);
            TotalReceipts += charge;
            Console.WriteLine($"Registration: {registrationNumber}, Hours Parked: {hoursParked:F2}, Charge: €{charge:F2}");
        }
    }
}

class Program
{
    static void Main()
    {
        ParkingGarage[] garages = {
            new ParkingGarage(0.50, 10),
            new ParkingGarage(0.60, 6),
            new ParkingGarage(0.75, 8)
        };

        double grandTotal = 0;
        for (int i = 0; i < garages.Length; i++)
        {
            Console.WriteLine($"Processing Car Park {i + 1}:");
            garages[i].ProcessCars();
            Console.WriteLine($"Total Receipts for Garage {i + 1}: €{garages[i].TotalReceipts:F2}\n");
            grandTotal += garages[i].TotalReceipts;
        }

        Console.WriteLine($"Grand Total for All Garages: €{grandTotal:F2}");
    }
}