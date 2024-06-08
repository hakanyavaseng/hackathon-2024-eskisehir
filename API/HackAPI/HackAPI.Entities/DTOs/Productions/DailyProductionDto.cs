namespace HackAPI.Entities.DTOs.Productions
{
    public record DailyProductionDto
    {
        public DateTime Day { get; set; }
        public decimal TotalCarbonFootprintCount { get; set; }
    }
}
