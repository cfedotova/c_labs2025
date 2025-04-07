class Program
{
    static void Main(string[] args)
    {
        TransportCompany cityTransport = new TransportCompany("City Transport Ltd.");
        
        Bus cityBus = new Bus("Mercedes Citaro", 300, 28, 85);
        Truck deliveryTruck = new Truck("Volvo FH16", 600, 35, 20);
        Taxi standardTaxi = new Taxi("Toyota Prius", 45, 5.5, 4, true);
        
        cityTransport.AddVehicle(cityBus);
        cityTransport.AddVehicle(deliveryTruck);
        cityTransport.AddVehicle(standardTaxi);
        
        cityTransport.DisplayFleet();
        
        RefuelingStation gasStation = new RefuelingStation(100);
        
        Console.WriteLine("\nPerforming operations:");
        Console.WriteLine("---------------------");
        
        cityTransport.SendVehicleOnTrip(0, 150);
        
        cityTransport.RefuelVehicle(0, 80, gasStation);
        
        cityTransport.SendVehicleOnTrip(1, 200);
        
        if (cityTransport.SendVehicleOnTrip(2, 30))
        {
            ((Taxi)cityTransport.GetFleet()[2]).StopMeter(30);
        }
        
        cityTransport.DisplayFleet();
    }
}