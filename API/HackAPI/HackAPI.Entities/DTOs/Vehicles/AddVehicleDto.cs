using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackAPI.Entities.DTOs.Vehicles
{
    public record AddVehicleDto
    {
        public string VehicleName { get; init; }
        public string VehicleType { get; init; }
        public string VehicleModel { get; init; } // Truck, Car, Bike, Bus, Train, Plane
        public decimal UnitCarbonFootprint { get; init; } // per Km
    }
}
