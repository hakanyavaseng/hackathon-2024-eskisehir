namespace HackAPI.Entities.Entities
{
    public class ProductionTransportation 
    {
        public Guid ProductionId { get; set; }
        public Guid TransportationId { get; set; }
        public Production Production { get; set; }
        public Transportation Transportation { get; set; }
    }
}
