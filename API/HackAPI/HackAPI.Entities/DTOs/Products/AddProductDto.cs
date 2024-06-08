namespace HackAPI.Entities.DTOs.Products
{
    public record AddProductDto
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
        public string Description { get; init; }
        public decimal UnitCarbonFootprint { get; init; }
    }
}
