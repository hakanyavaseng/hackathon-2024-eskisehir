namespace HackAPI.Entities.DTOs.Productions
{
    public record MonthlyProductionDto
    {
        public DateTime Month { get; set; }
        public decimal TotalCarbonFootprintCount { get; set; }
        
    }
}
