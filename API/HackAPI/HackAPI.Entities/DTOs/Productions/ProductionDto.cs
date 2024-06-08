using HackAPI.Entities.Entities;

namespace HackAPI.Entities.DTOs.Productions
{
    public record ProductionDto
    {
        public List<Product> Products { get; init; }
        public DateTime ProductionDateTime { get; init; }
        public decimal TotalCarbonFootprint { get; init; }

        
    }

}
