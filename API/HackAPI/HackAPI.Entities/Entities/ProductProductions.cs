namespace HackAPI.Entities.Entities
{
    public class ProductProductions 
    {
        public Guid ProductId { get; set; }
        public Guid ProductionsId { get; set; }
        public Product Product { get; set; }
        public Production Productions { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCarbonFootprint { get; set; }
    }
}
