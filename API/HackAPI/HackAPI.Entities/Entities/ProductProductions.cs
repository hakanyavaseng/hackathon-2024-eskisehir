using HackAPI.Entities.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackAPI.Entities.Entities
{
    public class ProductProductions : BaseEntity
    {
        [NotMapped]
        public override Guid Id { get => base.Id; set => base.Id = value; }
        [NotMapped]

        public override DateTime CreatedAt { get => base.CreatedAt; set => base.CreatedAt = value; }
        public Guid ProductId { get; set; }
        public Guid ProductionsId { get; set; }
        public Product Product { get; set; }
        public Production Productions { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCarbonFootprint { get; set; }
    }
}
