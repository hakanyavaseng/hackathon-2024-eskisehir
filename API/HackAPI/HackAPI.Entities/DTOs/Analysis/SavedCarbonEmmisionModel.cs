namespace HackAPI.Entities.DTOs.Analysis
{
    public record SavedCarbonEmmisionModel
    {
        public double SavedCarbonEmmision { get; init; }
        public int FossilFuelVehicleCount { get; init; }
    }
}
