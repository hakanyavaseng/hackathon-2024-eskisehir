using HackAPI.Entities.Entities;

namespace HackAPI.Entities.DTOs.Productions
{
    public record ProductionDto
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
        public List<Product> Products { get; init; }
        public DateTime ProductionDateTime { get; init; }
        public decimal TotalCarbonFootprint { get; init; }

        
    }

}
