using HackAPI.Entities.Entities.Common;

namespace HackAPI.Entities.Entities
{
    public class Transportation : BaseEntity
    {
        public DateTime TransportationDateTime { get; set; }
        public decimal Distance { get; set; }
        public Guid VehicleId { get; set; }
        public decimal TotalCarbonFootprint { get; set; }
        public ICollection<ProductionTransportation> ProductionTransportations { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
