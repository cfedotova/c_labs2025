public class Bus : Vehicle
{
    public int PassengerCapacity { get; private set; }

    public Bus(string model, double fuelCapacity, double fuelConsumption, int passengerCapacity)
        : base(model, fuelCapacity, fuelConsumption)
    {
        PassengerCapacity = passengerCapacity;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Bus: {Model}");
        Console.WriteLine($"Fuel Capacity: {FuelCapacity} liters");
        Console.WriteLine($"Current Fuel: {CurrentFuelLevel:F2} liters");
        Console.WriteLine($"Fuel Consumption: {FuelConsumption:F2} l/100km");
        Console.WriteLine($"Passenger Capacity: {PassengerCapacity}");
    }
}