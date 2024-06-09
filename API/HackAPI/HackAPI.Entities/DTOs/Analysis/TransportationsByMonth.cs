namespace HackAPI.Entities.DTOs.Analysis
{
    public record TransportationsByMonth
    {
        public List<ByMonthModel> Transportation { get; set; }
        public List<ByMonthModel> TotalCarbonFootprintIfElectrical { get; set;}

    }
}
