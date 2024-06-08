namespace HackAPI.Entities.DTOs.Productions
{
    public record YearlyProductionDto
    {
        public DateTime Year { get; set; }
        public decimal TotalCarbonFootprintCount { get; set; }
    }
}
