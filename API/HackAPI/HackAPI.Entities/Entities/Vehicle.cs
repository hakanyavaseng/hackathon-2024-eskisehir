using HackAPI.Entities.Entities.Common;

namespace HackAPI.Entities.Entities
{
    public class Vehicle : BaseEntity
    {
        public string VehicleName { get; set; }
        public string VehicleType { get; set; }
        public string VehicleModel { get; set; } // Truck, Car, Bike, Bus, Train, Plane
        public decimal UnitCarbonFootprint { get; set; } // per Km
    }
}
