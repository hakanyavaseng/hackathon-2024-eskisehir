using HackAPI.Entities.Entities.Common;

namespace HackAPI.Entities.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal UnitCarbonFootprint { get; set; }
        public ICollection<ProductProductions> ProductProductions { get; set; } 
    }
}

