namespace HackAPI.Entities.DTOs.Analysis
{
    public record ByMonthModel
    {
        public int MonthNumber { get; init; }
        public string MonthName { get; init; }
        public double TotalCarbonFootprintCount { get; init; }
    }
}
