using HackAPI.Entities.Entities;

namespace HackAPI.Entities.DTOs.Productions
{
    public record AddProductionDto
    {
        public ICollection<ProductProductions> ProductProductions { get; init; }
        public ICollection<ProductionTransportation> ProductionTransportations { get; init; }
       
    }
}
