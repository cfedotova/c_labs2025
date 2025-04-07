public static class TransportCompanyExtensions
{
    public static List<Vehicle> GetFleet(this TransportCompany company)
    {
        var fleetField = typeof(TransportCompany).GetField("Fleet", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (List<Vehicle>)fleetField.GetValue(company);
    }
}