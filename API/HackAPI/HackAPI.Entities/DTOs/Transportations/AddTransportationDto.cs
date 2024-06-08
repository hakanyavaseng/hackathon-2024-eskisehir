namespace HackAPI.Entities.DTOs.Transportations
{
    public class AddTransportationDto
    {
        public DateTime TransportationDateTime { get; init; }
        public decimal Distance { get; init; }
        public Guid VehicleId { get; init; }
        public decimal TotalCarbonFootprint { get; init; }


    }
}
