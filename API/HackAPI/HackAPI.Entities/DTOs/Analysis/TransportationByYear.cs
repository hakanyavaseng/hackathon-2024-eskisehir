namespace HackAPI.Entities.DTOs.Analysis
{
    public class TransportationByYear
    {
        public List<ByYearModel> Transportation { get; set; }
        public List<ByYearModel> TotalCarbonFootprintIfElectrical { get; set; }
    }
}
