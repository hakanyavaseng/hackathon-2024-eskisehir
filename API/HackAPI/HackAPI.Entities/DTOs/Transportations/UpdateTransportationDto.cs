namespace HackAPI.Entities.DTOs.Transportations
{
    public record UpdateTransportationDto
    {
        public Guid Id { get; init; }
        public DateTime TransportationDateTime { get; init; }
        public decimal Distance { get; init; }
        public Guid VehicleId { get; init; }
        public decimal TotalCarbonFootprint { get; init; }
    }
}
