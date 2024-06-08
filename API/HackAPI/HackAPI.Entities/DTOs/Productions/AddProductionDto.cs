using HackAPI.Entities.Entities;

namespace HackAPI.Entities.DTOs.Productions
{
    public record AddProductionDto
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
        public DateTime ProductionDateTime { get; init; }
      
    }
}
