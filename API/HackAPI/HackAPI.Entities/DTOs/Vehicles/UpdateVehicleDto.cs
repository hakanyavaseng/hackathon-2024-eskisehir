namespace HackAPI.Entities.DTOs.Vehicles
{
    public record UpdateVehicleDto
    {
        public Guid Id { get; init; }
        public string VehicleName { get; init; }
        public string VehicleType { get; init; }
        public string VehicleModel { get; init; } // Truck, Car, Bike, Bus, Train, Plane
        public decimal UnitCarbonFootprint { get; init; } // per Km


    }
}
