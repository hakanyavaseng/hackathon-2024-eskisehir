using HackAPI.Entities.Entities.Common;

namespace HackAPI.Entities.Entities
{
    public class Production : BaseEntity
    {     
         public ICollection<ProductProductions> ProductProductions { get; set; }
         public ICollection<ProductionTransportation> ProductionTransportations { get; set; }

    }
}
