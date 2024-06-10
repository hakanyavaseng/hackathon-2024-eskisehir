namespace HackAPI.Entities.DTOs.Analysis
{
    public record ByYearModel
    {
        public int Year { get; init; }
        public double TotalCarbonFootprintCount { get; init; }
       
    }
}
